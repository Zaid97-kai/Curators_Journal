using System.Text;
using AntDesign.TableModels;
using CuratorMagazineBlazorApp.Data.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ITable = AntDesign.ITable;

namespace CuratorMagazineBlazorApp.Pages.Admin.Role.Division;

/// <summary>
/// Class MenuItemDivision.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class MenuItemDivision
{
    /// <summary>
    /// Gets or sets the division service.
    /// </summary>
    /// <value>The division service.</value>
    [Inject]
    private DivisionService? DivisionService { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    private List<CuratorMagazineWebAPI.Models.Entities.Domains.Division>? _divisions;

    /// <summary>
    /// The selected rows
    /// </summary>
    private IEnumerable<CuratorMagazineWebAPI.Models.Entities.Domains.Division>? _selectedRows;
    /// <summary>
    /// The table
    /// </summary>
    private ITable? _table;

    /// <summary>
    /// The edit cache
    /// </summary>
    private IDictionary<string, (bool edit, CuratorMagazineWebAPI.Models.Entities.Domains.Division data)> _editCache = new Dictionary<string, (bool edit, CuratorMagazineWebAPI.Models.Entities.Domains.Division data)>();

    /// <summary>
    /// The page index
    /// </summary>
    int _pageIndex = 1;

    /// <summary>
    /// The page size
    /// </summary>
    int _pageSize = 10;

    /// <summary>
    /// The total
    /// </summary>
    int _total = 0;

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await DivisionService?.PostAsync()!;
        
        _divisions = JsonConvert.DeserializeObject<List<CuratorMagazineWebAPI.Models.Entities.Domains.Division>>(ret.Result.Items?.ToString() ?? string.Empty);

        _divisions?.ForEach(item =>
        {
            _editCache[item.Id.ToString()] = (false, item);
        });

        if (_divisions != null) _total = _divisions.Count;
    }

    /// <summary>
    /// Starts the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void StartEdit(string id)
    {
        var data = _editCache[id];
        _editCache[id] = (true, data.data);
    }

    /// <summary>
    /// Cancels the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void CancelEdit(string id)
    {
        if (_divisions != null)
        {
            var data = _divisions.FirstOrDefault(item => item.Id == Convert.ToInt32(id));
            _editCache[id] = (false, data)!;
        }
    }

    /// <summary>
    /// Saves the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private async void SaveEdit(string id)
    {
        if (_divisions != null)
        {
            var index = _divisions.FindIndex(item => item.Id == Convert.ToInt32(id));
            _divisions[index] = _editCache[id].data;
            _editCache[id] = (false, _divisions[index]);
        }

        var ret = await DivisionService?.PutAsync(_editCache[id].data)!;

        Console.WriteLine(ret.Success ? $"{_editCache[id].data} is updated!" : ret.Error);
    }

    /// <summary>
    /// Called when [change].
    /// </summary>
    /// <param name="queryModel">The query model.</param>
    public async Task OnChange(QueryModel<CuratorMagazineWebAPI.Models.Entities.Domains.Division> queryModel)
    {
        Console.WriteLine(JsonConvert.SerializeObject(queryModel));
    }

    /// <summary>
    /// Removes the selection.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public void RemoveSelection(int id)
    {
        if (_selectedRows != null)
        {
            var selected = _selectedRows.Where(x => x.Id != id);
            _selectedRows = selected;
        }
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void Delete(int id)
    {
        if (_divisions != null)
        {
            _divisions = _divisions.Where(x => x.Id != id).ToList();
            _total = _divisions.Count;
        }
    }
}