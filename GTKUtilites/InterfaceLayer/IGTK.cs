using System.Collections.Generic;
using System.Data;

namespace GTKUtilites.InterfaceLayer
{


    public interface IGTK<T>
    {
        string ParentNode { get; }
        string ChildNode { get; }
        T GetNewRow();
        List<T> GetDetails(DataTable dtDetails);
        void RemoveDetails(ref T type);
        string PrepareSaveXml(List<T> liValues);

    }
 }
