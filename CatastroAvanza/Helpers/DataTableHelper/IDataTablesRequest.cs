namespace CatastroAvanza.Helpers.DataTableHelper
{
    //
    // Summary:
    //     Defines a server-side request for use with DataTables.
    //
    // Remarks:
    //     Variable syntax does NOT match DataTables names because auto-mapping won't work
    //     anyway. Use the DataTablesModelBinder or provide your own binder to bind your
    //     model with DataTables's request.
    public interface IDataTablesRequest
    {
        //
        // Summary:
        //     Gets and sets the draw counter from client-side to give back on the server's
        //     response.
        int Draw { get; set; }
        //
        // Summary:
        //     Gets and sets the start record number (count) for paging.
        int Start { get; set; }
        //
        // Summary:
        //     Gets and sets the length of the page (max records per page).
        int Length { get; set; }
        //
        // Summary:
        //     Gets and sets the global search pagameters.
        Search Search { get; set; }
        //
        // Summary:
        //     Gets and sets the read-only collection of client-side columns with their options
        //     and configs.
        ColumnCollection Columns { get; set; }
    }
}
