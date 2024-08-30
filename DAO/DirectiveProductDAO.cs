using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DirectiveProductDAO
    {
           
        private static DirectiveProductDAO instance;

        public static DirectiveProductDAO Instance
        {
            get { if (instance == null) instance = new DirectiveProductDAO(); return instance; }
            set => instance = value;
        }

        public DirectiveProductDAO(){ }     
        public DataTable GetTable()
        {
            string query = "select * from DirectiveProduct,Part,Machine,Mold,Material WHERE IdPart=Part.Id and IdMachine=Machine.Id and IdMold = Mold.Id and Part.MatCode=Material.MatCode ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable GetTable(DateTime DateStart, DateTime DateEnd)
        {
            string query = "select * from DirectiveProduct,Part,Machine,Mold,Material WHERE IdPart=Part.Id and IdMachine=Machine.Id" +
                " and IdMold = Mold.Id and Part.MatCode=Material.MatCode  and DateInput>= @1 and DateInput <= @2 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]{DateStart,DateEnd});
            return data;
        }

        //  insert DirectiveProduct(Id,DateInput, IdPart, Quantity, IdMachine, IdMold, NoteProduct, NoteMaterial, FactoryCode, WeightUse, WeightOut, Status, Note)

        public int Insert(DateTime DateInput,int IdPart,int Quantity,int IdMachine,int IdMold,string NoteProduct,string  NoteMaterial,string FactoryCode,
           float WeightUse,float WeightOut,int Status,string Note)
        {
            string query = "insert DirectiveProduct(DateInput, IdPart, Quantity, IdMachine, IdMold, NoteProduct, NoteMaterial, FactoryCode, WeightUse, WeightOut, Status, Note) " +
                                            "values( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 , @9 , @10 , @11 , @12 ) ";                                   
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DateInput, IdPart, Quantity, IdMachine, IdMold, NoteProduct,  NoteMaterial, FactoryCode,
            WeightUse,WeightOut, Status,Note});
            return data ;
        }

        public int Update(long Id,DateTime DateInput, int IdPart, int Quantity, int IdMachine, int IdMold, string NoteProduct, string NoteMaterial, string FactoryCode,
           float WeightUse, float WeightOut, int Status, string Note)
        {
            string query = "Update DirectiveProduct set DateInput= @1 ,IdPart= @2 , Quantity= @3 , IdMachine= @4 ,IdMold= @5 , NoteProduct= @6 , NoteMaterial= @7 ," +
                " FactoryCode= @8 ,WeightUse= @9 , WeightOut= @10 , Status= @11 , Note= @12 where Id= @13 ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {DateInput, IdPart, Quantity, IdMachine, IdMold, NoteProduct,  NoteMaterial, FactoryCode,
            WeightUse,WeightOut, Status,Note,Id});      
            return data;
        }

        public int UpdateStatusCTSX(long Id,int Status, string Note)
        {
            string query = "update DirectiveProduct set Status= @status ,Note= @note where Id = @Id ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {Status,Note,Id });
            return data;
        }

        public int Delete(long Id)
        {
            string query = "delete DirectiveProduct where Id = @Id ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { Id});
            return data;
        }

    }
}
