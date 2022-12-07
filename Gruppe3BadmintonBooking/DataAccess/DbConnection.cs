using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class DbConnection
    {
        public static SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder()
        { DataSource = "hildur.ucn.dk", InitialCatalog = "DMA-CSD-S212_10407522", Encrypt = false, UserID = "DMA-CSD-S212_10407522", Password = "Password1!" };
    }
}
