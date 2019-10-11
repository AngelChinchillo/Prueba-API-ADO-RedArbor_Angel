using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RedArbor.Helper;
using RedArbor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RedArbor.Services
{
    //Métodos comúnes para testear valores de datos validos
    public  class CheckData
    {
        //Si la fecha es inferior a 1753 no puede ser insertada en base de datos
        public DateTime CheckDatetimeRange(DateTime dateTimeToValidate)
        {
            if (dateTimeToValidate.Year < 1753)
            {
                throw new Exception(TAG.INVALID_DATE);
            }
            return dateTimeToValidate;
        }

    }
}
