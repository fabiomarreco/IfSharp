// include directory, this will be replaced by the kernel
#I "{0}"

// load base dlls
#r "IfSharp.Kernel.dll"
#r "NetMQ.dll"

// open the global functions and methods
open IfSharp.Kernel
open IfSharp.Kernel.Globals

#load "Paket.fsx"
#load "Paket.Generated.Refs.fsx"
#I ".."
#I "packages"
#nowarn "211"
#load "packages/fslab/fslab.fsx"

#if HAS_FSI_ADDHTMLPRINTER
type FSStyleFormat = 
    | FSStyle_table_float_format of string
    | FSStyle_math_float_format of string
    | FSStyle_vector_item_counts of (int * int)
    | FSStyle_matrix_column_counts of (int * int)
    | FSStyle_matrix_row_counts of (int * int)
    | FSStyle_grid_row_counts of (int * int)
    | FSStyle_grid_column_counts of (int * int)


let FSL_set_style = 
  function
  | FSStyle_table_float_format f -> fsi.HtmlPrinterParameters.[ "table-float-format"] <- f
  | FSStyle_math_float_format f -> fsi.HtmlPrinterParameters.[ "math-float-format" ] <- f
  | FSStyle_vector_item_counts (r, c) -> fsi.HtmlPrinterParameters.["vector-item-counts"] <- r.ToString() + "," + c.ToString()
  | FSStyle_matrix_column_counts (r, c) -> fsi.HtmlPrinterParameters.["matrix-column-counts"] <- r.ToString() + "," + c.ToString()
  | FSStyle_matrix_row_counts (r, c) -> fsi.HtmlPrinterParameters.["matrix-row-counts"] <- r.ToString() + "," + c.ToString()
  | FSStyle_grid_row_counts (r, c) -> fsi.HtmlPrinterParameters.["grid-row-counts"] <- r.ToString() + "," + c.ToString()
  | FSStyle_grid_column_counts (r, c) -> fsi.HtmlPrinterParameters.["grid-column-counts"] <- r.ToString() + "," + c.ToString()



FSL_set_style (FSStyle_table_float_format "0.######")

#endif

