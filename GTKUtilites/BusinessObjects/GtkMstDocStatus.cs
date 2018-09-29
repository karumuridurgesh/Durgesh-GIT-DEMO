using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.BusinessObjects
{
    public class GtkMstDocStatus
    {
        public string StatusTypeId { get; set; } //1
        public string EntityId { get; set; } //2
        public string StatusType { get; set; } //3
        public string StatusSubType { get; set; } //4
        public string Descr { get; set; } //5
        public string CreatedBy { get; set; } //6
        public string CreatedDate { get; set; } //7
        public string ModifiedBy { get; set; } //8
        public string ModifiedDate { get; set; } //9
    }
}
