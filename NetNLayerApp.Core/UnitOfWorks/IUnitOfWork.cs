using NetNLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.UnitOfWorks
{
    interface IUnitOfWork
    {
        IProductRepository Products { get; }

        ICategoryRepository categories { get; }

        Task CommitAsync(); //implemente edildiginde ef tarafinda savechange metodunu cagirir. 

        void Commit();
    }
}
