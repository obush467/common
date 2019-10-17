using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Interfaces
{
    public interface ICreateDirParams
    {
        string Name { get; set; }
        string ParentPath { get; set; }
    }
    public interface ICreateFileParams : ICreateDirParams
    {
        Byte[] File_stream { get; set; }

        bool Is_hidden { get; set; }

        bool Is_readonly { get; set; }

        bool Is_archive { get; set; }

        bool Is_system { get; set; }

        bool Is_temporary { get; set; }
    }
    public interface IRenameParams : IStreamId
    {
        string Name { get; set; }
    }
    public interface IStreamId
    {
        Guid Stream_id { get; set; }
    }
    public interface IUpdateParams : IStreamId
    {
        Byte[] File_stream { get; set; }
    }
}
