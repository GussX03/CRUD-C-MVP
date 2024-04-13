using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_C__MCP.Views;
using CRUD_C__MCP.Presenters;
using CRUD_C__MCP.Models;
using CRUD_C__MCP._Repositories;
using System.Configuration;

namespace CRUD_C__MCP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IPetView view = new PetView();
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(view, repository);
            Application.Run((Form)view);
        }
    }
}
