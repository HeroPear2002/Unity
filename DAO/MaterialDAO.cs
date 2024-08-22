using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
   public class MaterialDAO
    {
        private static MaterialDAO instance;

        public static MaterialDAO Instance
        {
            get { if (instance == null) instance = new MaterialDAO(); return instance; }
            set => instance = value;
        }
        public MaterialDAO() { }
        public List<MaterialDTO> Getlist()
        {
            string query = "SELECT Material.Id,MatCode,MatName,WarnYllow,WarnCount ,IdSup,SupCode,Nature,RohsFile,ColorCode,Material.Note FROM dbo.Material,dbo.Supplier WHERE IdSup=Supplier.Id ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<MaterialDTO> lsv = new List<MaterialDTO>();
            foreach (DataRow item in data.Rows)
            {
                MaterialDTO DTO = new MaterialDTO(item);
                lsv.Add(DTO);
            }
            return lsv;
        }
        public MaterialDTO GetItem( int id)
        {
            string query = " SELECT Material.Id,MatCode,MatName,WarnYllow,WarnCount ,IdSup,SupCode,Nature,RohsFile,ColorCode,Material.Note FROM dbo.Material,dbo.Supplier WHERE IdSup=Supplier.Id and  Material.Id = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id});           
            foreach (DataRow item in data.Rows)
            {
                MaterialDTO DTO = new MaterialDTO(item);
                return DTO;
            }
            return null;
        }
        public MaterialDTO GetItem(string code)
        {
            string query = " SELECT Material.Id,MatCode,MatName,WarnYllow,WarnCount ,IdSup,SupCode,Nature,RohsFile,ColorCode,Material.Note FROM dbo.Material,dbo.Supplier WHERE IdSup=Supplier.Id and  MatCode = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { code });
            foreach (DataRow item in data.Rows)
            {
                MaterialDTO DTO = new MaterialDTO(item);
                return DTO;
            }
            return null;
        }
        public int Insert(string matco, string matna, int warny, int warnc, int idsup, string nature, string rohs, string color, string note)
        {
            string query = " INSERT dbo.Material ( MatCode , MatName , WarnYllow , WarnCount , IdSup , Nature , RohsFile ,  ColorCode , Note ) VALUES ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 ) ";
            int  data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matco,matna,warny,warnc,idsup,nature,rohs,color,note });
            return data;
        }
        public int Update(int id,string matco, string matna, int warny, int warnc, int idsup, string nature, string rohs, string color, string note)
        {
            string query = " Update dbo.Material set MatCode= @1 , MatName= @2 , WarnYllow= @3 , WarnCount= @4 , IdSup= @5 , Nature = @6 , RohsFile= @7 , ColorCode= @8 , Note= @9 where ID= @10 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matco, matna, warny, warnc, idsup, nature, rohs, color, note , id });
            return data;
        }
        public int Delete(int id)
        {
            string query = " Delete dbo.Material where Id= @1 ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return data;
        }
        public int check ( string MatCode)
        {
            string query = "select * from Material where MatCode = @1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MatCode });
            return data.Rows.Count;
        }
    }
}
