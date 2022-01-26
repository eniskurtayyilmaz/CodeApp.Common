# CodeApp.Oracle

| Name | Status |
| ------ | ------ |
| Tests | ![Build and Tests](https://github.com/eniskurtayyilmaz/CodeApp.Oracle/actions/workflows/main.yml/badge.svg) |
| Nuget Published |[![Deploy to NuGet](https://github.com/eniskurtayyilmaz/CodeApp.Oracle/actions/workflows/nuget.yml/badge.svg)](https://www.nuget.org/packages/CodeApp.Oracle/) |

### Dependency
- .Net Framework >= 4.5.2

### Motivation
As we are CodeApp, we have an important customer and they have 30+ webservices. But previous developer was added same code blocks in each webservices. I think the guy was junior, because the DB queries, connection's open-closes called in Controllers! And also all of business rules! It's not acceptable. So, the job came us by customer. I created small library to call DB connection. If there is a maintenance one of them webservice, I was added from Nuget.  


### Installation
- Generate your own repository and implement by _BaseRepository_
- Write your DB queries or stored procedures

### Example Create Your Own Repository
```csharp
using Dapper;
using ExampleService.Models;
using ExampleService.Utils.Helpers;
using ExampleService.Utils.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleService.Repositories
{
    public interface IExampleRepository : IBaseRepository<ExampleRequest, ExampleResponse>
    {
        ....
    }

    public class ExampleRepository : IExampleRepository
    {
        private readonly IDatabaseConnectionFactory dbConnection;

        public ExampleRepository(IDatabaseConnectionFactory dbConnection)
        {
            this.dbConnection = dbConnection;
        }

		.....
		.....
		
        public ExampleResponse Execute(ExampleRequest model)
        {
            try
            {
                using (var connection = dbConnection.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@P_TCKN", model.TCKN, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_DOGRULAMA_KODU", model.DogrulamaKodu, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_TRANSACTION_ID", model.TransactionId, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_OTP", model.OTP, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_OTP_DOGRULAMA_ZAMAN", model.OtpDogrulamaZaman, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_KYC_ONAY_ZAMAN", model.ExampleZaman, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_DOGRULAMA_YUZDESI", model.DogrulamaYuzdesi, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_GORUSULEN_MT", model.GorusulenMT, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_GORUSME_BASLANGIC", model.GorusmeBaslangic, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_GORUSME_BITIS", model.GorusmeBıtıs, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_ONAYLAYAN", model.layan, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_GORUSME_DOSYA_ID", model.GorusmeDosyaId, DbType.String, ParameterDirection.Input, 2500);
                    parameters.Add("@P_KREDI_NO", model.KrediNo, DbType.String, ParameterDirection.Input, 2500);

                    parameters.Add("@P_KYC_ONAY", dbType: DbType.String, direction: ParameterDirection.Output, size: 2500);
                    parameters.Add("@P_HATA_KODU", dbType: DbType.String, direction: ParameterDirection.Output, size: 2500);
                    parameters.Add("@P_HATA_ACIKLAMA", dbType: DbType.String, direction: ParameterDirection.Output, size: 2500);


                    var updateResult = connection.Query<ExampleResponse>("FINANS.SPK_KYC.SP_KYC_ONAY", parameters, commandType: CommandType.StoredProcedure);
                    var response = new ExampleResponse()
                    {
                        Example = parameters.Get<string>("@P_KYC_ONAY"),
                        Kod = parameters.Get<string>("@P_HATA_KODU"),
                        KodAciklama = parameters.Get<string>("@P_HATA_ACIKLAMA"),
                    };
                    return response;
                }
            }
            catch (Exception ex)
            {
                return new ExampleResponse(ConstantHelpers.BaseResponseDefaultKod, ex.Message);
            }
        }
		....
    }
}
````