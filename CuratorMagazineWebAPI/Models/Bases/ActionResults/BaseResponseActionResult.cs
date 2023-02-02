// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-21-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="BaseResponseActionResult.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Bases;

namespace CuratorMagazineWebAPI.Models.Bases.ActionResults;

/// <summary>
/// Class BaseResponseActionResult. This class cannot be inherited.
/// Implements the <see cref="IConvertToActionResult" />
/// </summary>
/// <typeparam name="TValue">The type of the t value.</typeparam>
/// <seealso cref="IConvertToActionResult" />
public sealed class BaseResponseActionResult<TValue> : IConvertToActionResult
{
    /// <summary>
    /// Initializes a new instance of <see cref="ActionResult{TValue}" /> using the specified <paramref name="value" />.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="System.ArgumentException"></exception>
    public BaseResponseActionResult(TValue value)
    {
        if (typeof(IActionResult).IsAssignableFrom(typeof(BaseResponse<TValue>)))
        {
            var error = $"{typeof(BaseResponse<TValue>)}: Value is assignable to IActionResult. Convert unavailable.";
            throw new ArgumentException(error);
        }

        Value = new BaseResponse<TValue>(value);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ActionResult{TValue}" /> using the specified <see cref="ActionResult" />.
    /// </summary>
    /// <param name="result">The <see cref="ActionResult" />.</param>
    /// <exception cref="System.ArgumentException"></exception>
    /// <exception cref="System.ArgumentNullException">result</exception>
    public BaseResponseActionResult(ActionResult result)
    {
        if (typeof(IActionResult).IsAssignableFrom(typeof(BaseResponse<TValue>)))
        {
            var error = $"{typeof(BaseResponse<TValue>)}: Value is assignable to IActionResult. Convert unavailable.";
            throw new ArgumentException(error);
        }

        Result = result ?? throw new ArgumentNullException(nameof(result));
    }

    /// <summary>
    /// Gets the <see cref="ActionResult" />.
    /// </summary>
    /// <value>The result.</value>
    public ActionResult Result { get; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <value>The value.</value>
    public BaseResponse<TValue> Value { get; }

    /// <summary>
    /// Чтобы в контроллере просто написать return effectAddsDto - без оберток В OK(effectAddsDto), например.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The result of the conversion.</returns>

    public static implicit operator BaseResponseActionResult<TValue>(TValue value)
    {
        return new BaseResponseActionResult<TValue>(value);
    }
    /// <summary>
    /// Чтобы в контроллере просто написать return BadRequest() - без оберток в new ActionResult(), например
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator BaseResponseActionResult<TValue>(ActionResult result)
    {
        return new BaseResponseActionResult<TValue>(result);
    }

    /// <summary>
    /// Если возвращаем через return effectAddsDto, то Result - пустой, если возвращаем через return BadRequest(), то Value пустая, но до её обработка и не доходит
    /// </summary>
    /// <returns>IActionResult.</returns>
    IActionResult IConvertToActionResult.Convert()
    {
        return Result ?? new ObjectResult(Value)
        {
            DeclaredType = typeof(BaseResponse<TValue>),
        };
    }
}