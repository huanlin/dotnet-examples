using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Logging;
using InfoShare.Text2Tip.Core.Model;

namespace InfoShare.Text2Tip.Application.Services
{
    public class Text2TipServiceBase : IDisposable
    {
        protected ILog _logger;
        protected Text2TipEntities _db;
        //protected Models.InfoRmsContext dbRms;

        public Text2TipServiceBase()
        {
            _logger = LogManager.GetLogger(GetType());
            _db = new Text2TipEntities();
        }

        public void Dispose()
        {
            _db.Dispose();
            _db = null;

            //dbRms.Dispose();
            //dbRms = null;
        }
    }
}
