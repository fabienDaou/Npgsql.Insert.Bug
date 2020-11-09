using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Npgsql.Insert.Bug
{
    [TestClass]
    public class InsertTests
    {
        private const string ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=" + DatabaseName;
        private const string DatabaseName = "inserttest";

        [TestInitialize]
        public void Setup()
        {
            NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
            CleanupAndSetup();
        }

        [TestMethod]
        public void InsertTest()
        {
            var tuples = new List<(int, string)>
            {
                (1301, "faithtap.com"),
                (1302, "ibtimes.co.uk"),
                (1303, "audible.com"),
                (1304, "idntimes.com"),
                (1305, "eroterest.net"),
                (1306, "nhl.com"),
                (1307, "wikispaces.com"),
                (1308, "smallpdf.com"),
                (1309, "bestadbid.com"),
                (1310, "time2play-online.net"),
                (1311, "kinoprofi.org"),
                (1312, "opensubtitles.org"),
                (1313, "digitalocean.com"),
                (1314, "worldstarhiphop.com"),
                (1315, "mediab.uy"),
                (1316, "watchfree.to"),
                (1317, "aksam.com.tr"),
                (1318, "ficbook.net"),
                (1319, "clevernt.com"),
                (1320, "ivi.ru"),
                (1321, "gotowebinar.com"),
                (1322, "yandex.kz"),
                (1323, "programme-tv.net"),
                (1324, "businessweekly.com.tw"),
                (1325, "topeasysofttoigetalwaysfree.website"),
                (1326, "talk.tw"),
                (1327, "ozipcompression.com"),
                (1328, "24h.com.vn"),
                (1329, "alicdn.com"),
                (1330, "ku6.com"),
                (1331, "banesconline.com"),
                (1332, "t-mobile.com"),
                (1333, "liftable.com"),
                (1334, "telegraf.com.ua"),
                (1335, "akairan.com"),
                (1336, "lightinthebox.com"),
                (1337, "google.com.cu"),
                (1338, "irecommend.ru"),
                (1339, "entrepreneur.com"),
                (1340, "storm.mg"),
                (1341, "znanija.com"),
                (1342, "userscloud.com"),
                (1343, "elvenar.com"),
                (1344, "commbank.com.au"),
                (1345, "tomsguide.com"),
                (1346, "4399.com"),
                (1347, "streamin.to"),
                (1348, "blog.ir"),
                (1349, "gap.com"),
                (1350, "ebates.com"),
                (1351, "abrtn.pro"),
                (1352, "trackingclick.net"),
                (1353, "habrahabr.ru"),
                (1354, "ukr.net"),
                (1355, "forgeofempires.com"),
                (1356, "leo.org"),
                (1357, "pexels.com"),
                (1358, "3c.tmall.com"),
                (1359, "geeker.com"),
                (1360, "toponclick.com"),
                (1361, "hateblo.jp"),
                (1362, "life.ru"),
                (1363, "jiameng.com"),
                (1364, "abc.es"),
                (1365, "plarium.com"),
                (1366, "dagospia.com"),
                (1367, "telekom.com"),
                (1368, "plays.tv"),
                (1369, "clickfunnels.com"),
                (1370, "envato.com"),
                (1371, "blogspot.tw"),
                (1372, "indianrail.gov.in"),
                (1373, "file-upload.cc"),
                (1374, "sozcu.com.tr"),
                (1375, "credit-agricole.fr"),
                (1376, "flaticon.com"),
                (1377, "zjk24.com"),
                (1378, "hibapress.com"),
                (1379, "geocities.jp"),
                (1380, "rutube.ru"),
                (1381, "kdnet.net"),
                (1382, "brand.tmall.com"),
                (1383, "qualtrics.com"),
                (1384, "wayfair.com"),
                (1385, "united.com"),
                (1386, "pierces.xyz"),
                (1387, "dhgate.com"),
                (1388, "namasha.com"),
                (1389, "aa.com"),
                (1390, "blogspot.com.tr"),
                (1391, "tripadvisor.co.uk"),
                (1392, "musica.com"),
                (1393, "mlb.com"),
                (1394, "caf.fr"),
                (1395, "mgid.com"),
                (1396, "southcn.com"),
                (1397, "mufg.jp"),
                (1398, "index.hu"),
                (1399, "korabia.com"),
                (1400, "tandfonline.com")
            };
            var entities = tuples.Select(t => new SomeSpecificDocument
            {
                Rank = t.Item1,
                Domain = t.Item2
            });

            var accessor = new SomeSpecificDocumentsAccessor(ConnectionString);

            accessor.Add(entities);
        }

        private static void CleanupAndSetup()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var createTableCommand = new NpgsqlCommand($"DROP TABLE IF EXISTS \"{nameof(EntityContext.SomeSpecificDocumentss)}\"", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                using (var createTableCommand = new NpgsqlCommand($"CREATE TABLE \"{nameof(EntityContext.SomeSpecificDocumentss)}\" (\"Id\" character varying(512), \"Document\" jsonb, CONSTRAINT primary_key_{nameof(EntityContext.SomeSpecificDocumentss)} PRIMARY KEY(\"Id\"));", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
