using BOOKMAN.ConsoleApp.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework

namespace BOOKMAN.ConsoleApp.Framework
{
    /*đây không phải là lệnh sử dụng không gian tên
    * mà là tạo biệt danh cho một kiểu dữ liệu
    * ở đây đang tạo một biệt danh cho kiểu Dictionary<string, ControllerAction>.
    * trong cả file này có thể sử dụng tên kiểu RoutingTable
    * thay cho Dictionary<string, ControllerAction>
    * Lưu ý rằng khai báo này nằm trực tiếp trong namespace
    */
    using RoutingTable = Dictionary<string, ControllerAction>;
    //lưu ý rằng khai báo này nằm trực tiếp trong namespace
    /// <summary>
    /// delegate này đại diện cho tất cả các phương thức có:
    /// - kiểu ra là void,
    /// - danh sách tham số vào là (Parameter)
    /// </summary>
    /// <param name="parameter"></param>
    public delegate void ControllerAction(Parameter parameter = null);
    /// <summary>
    /// lớp cho phép ánh xạ truy vấn với phương thức
    /// </summary>
    public class Router
    {
        // nhóm 3 lệnh dưới đây biến Router thành một singleton
        private static Router instance;
        private Router()
        {
            routingTable = new RoutingTable();
            helpTable = new Dictionary<string, string>();
        }
        // để ý: constructor là private
        // người sử dụng class thông qua property này để truy xuất các phương thức của class
        // chỉ khi nào _instance == null mới tạo object. Một khi đã tạo object, _instance sẽ
        // không có giá trị null nữa.
        // vì là biến static, instance một khi được khởi tạo sẽ tồn tại suốt chương trình
        public static Router Instance => instance ?? (instance = new Router());
        // lưu ý: ở đây đang sử dụng alias của Dictionary<string, ControllerAction> cho ngắn gọn
        private readonly RoutingTable routingTable;
        private readonly Dictionary<string, string> helpTable;
        public string GetRoutes()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var k in routingTable.Keys)
            {
                sb.AppendFormat("{0},", k);
            }
            return sb.ToString();
        }
        public string GetHelp(string key)
        {
            if (helpTable.ContainsKey(key))
                return helpTable[key];
            else
                return "Documentation not ready yet!";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route"></param>
        /// <param name="action"></param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            // nếu _routingTable đã chứa route này thì bỏ qua
            if(!routingTable.ContainsKey(route))
            {
                routingTable[route] = action;
                helpTable[route] = help;
            }
        }
        /// <summary>
        /// phân tích truy vấn và gọi phương thức tương ứng với chuỗi truy vấn
        /// <para>chuỗi truy vấn bao gồm hai phần: route và parameter, phân tách bởi ký tự ?</para>
        /// </summary>
        /// <param name="request">chuỗi truy vấn, bao gồm hai phần: 
        /// route, paramete; phân tách bởi ký tự ?</param>
        public void Forward(string request)
        {
            var req = new Request(request);
            if (!routingTable.ContainsKey(req.Route))
                throw new Exception("Command not Found!");
            if (req.Parameter == null)
                routingTable[req.Route]?.Invoke();
            else
                routingTable[req.Route]?.Invoke(req.Parameter);
        }
        /// <summary>
        ///  lớp xử lý truy vấn
        /// </summary>
        private class Request
        {
            /// <summary>
            /// thành phần lệnh của truy vấn
            /// </summary>
            public string Route { get; private set; }
            /// <summary>
            /// thành phần tham số của truy vấn
            /// </summary>
            public Parameter Parameter { get; private set; }
            public Request(string request)
            {
                Analyze(request);
            }
            /// <summary>
            /// phân tích truy vấn để tách ra thành phần lệnh và thành phần tham số
            /// </summary>
            /// <param name="request"></param>
            private void Analyze(string request)
            {
                // tìm xem trong chuỗi truy vấn có tham số hay không
                var firstIndex = request.IndexOf('?');
                // trường hợp truy vấn không chứa tham số
                if (firstIndex < 0)
                {
                    Route = request.ToLower().Trim();
                }
                // trường hợp truy vấn chứa tham số
                else
                {
                    // nếu chuỗi lối (chỉ chứa tham số, không chứa route)
                    if (firstIndex <= 1) throw new Exception("Invalid request parameter");
                    // cắt chuỗi truy vấn lấy mốc là ký tự ?
                    // sau phép toán này thu được mảng 2 phần tử: thứ nhất là route, thứ hai là chuỗi parameter
                    var tokens = request.Split(new[] { '?' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    //route là thành phần lệnh của truy vấn
                    Route = tokens[0].Trim().ToLower();
                    //parameter là thành phần tham số của truy vấn
                    var parameterPart = request.Substring(firstIndex + 1).Trim();
                    Parameter = new Parameter(parameterPart);
                }
            }
        }
    }
}
