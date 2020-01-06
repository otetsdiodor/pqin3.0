using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMF
{
    public class NastedContext : DbContext, IDisposable
    {
        //public string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-Pain-20200103120012;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-pqin3.0-20200106113228;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public object GetByName(Type t, string Name, bool flag = true)
        {
            var TableName = (GetTablenameFromAttribute(t) == null) ? t.Name : GetTablenameFromAttribute(t);

            using (var connection = new SqlConnection(str))
            {
                LoadedTypes.Add(TableName);
                connection.Open();
                var TableInfo = GetTableInfo(TableName);
                var commandText = string.Format("SELECT * FROM {0} WHERE UserName = '{1}';", TableName, Name);
                var reader = new SqlCommand(commandText, connection).ExecuteReader();

                while (reader.Read())
                {
                    var CtorParams = new List<object>();
                    foreach (var item in TableInfo)
                    {
                        if (item.Key == "Descriminator")
                            t = GetTypeByName(reader[item.Key].ToString());
                        else
                            CtorParams.Add(reader[item.Key]);
                        if (GetForeighKeysList(TableName).Contains(item.Key))
                            if (flag)
                            {
                                var type = GetTypeByName(item.Key.Replace("Id", ""));
                                var o = GetById(type, CtorParams.LastOrDefault().ToString(), false);
                                CtorParams.Add(o);
                            }
                            else
                                CtorParams.Add(null);
                    }

                    foreach (var TypeName in GetTypeOneToMany(t))
                    {
                        if (flag)
                        {
                            var type = GetTypeByName(TypeName);
                            var smt = (GetTablenameFromAttribute(type) == null) ? type.Name : GetTablenameFromAttribute(type);
                            var searchRes = "";

                            foreach (var item in GetForeighKeysList(smt))
                                if (item.Contains(TableName))
                                    searchRes = item;

                            var listOfType = getList(CtorParams.FirstOrDefault().ToString(), searchRes, type, false);

                            var listInstance = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { type }));
                            foreach (var item in listOfType)
                                listInstance.Add(item);

                            CtorParams.Add(listInstance);
                        }
                        else
                            CtorParams.Add(null);
                    }
                    return Activator.CreateInstance(t, CtorParams.ToArray());
                }
                return null;
            }
        }

        public static NastedContext Create()
        {
            return new NastedContext();
        }

        public void Dispose()
        {
            Console.WriteLine("DISPOSED HAHA");
        }
    }
}
