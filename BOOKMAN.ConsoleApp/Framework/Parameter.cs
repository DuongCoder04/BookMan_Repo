using System;
using System.Collections.Generic;

namespace BOOKMAN.ConsoleApp.Framework
{
    public class Parameter
    {
        private readonly Dictionary<string, string> pairs = new Dictionary<string, string>();
        /// <summary>
        /// chồng phép toán indexing []; cho phép truy xuất giá trị theo kiểu biến[khóa] = giá_trị;
        /// </summary>
        /// <param name="key">khóa</param>
        /// <returns>giá trị tương ứng</returns>
        public string this[string key]// để nạp chồng phép toán indexing phải viết hai phương thức get,set
        {
            get 
            { 
                if (pairs.ContainsKey(key)) return pairs[key];
                else return null;
            } // phương thức get trả lại giá trị từ dictionary
            set=> pairs[key] = value; //phương thức set gán giá trị cho dictionary
        }
        /// <summary>
        /// tra xem một khóa có trong danh sách tham số không
        /// </summary>
        /// <param name="key">khóa cần kiểm tra</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return pairs.ContainsKey(key);
        }

        public Parameter(string parameter)
        {
            // cắt chuỗi theo mốc là ký tự &
            // kết quả của phép toán này là một mảng, mỗi phần tử là một chuỗi có dạng khóa = giá_trị
            var pairs = parameter.Split(new[] {'&'},StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var p = pair.Split('='); // cắt mỗi phần tử lấy mốc là ký tự =
                if(p.Length == 2)// một cặp khóa = giá_trị đúng sau khi cắt sẽ phải có 2 phần
                {
                    var key = p[0].Trim(); //phần tử thứ nhất là khóa
                    var value = p[1].Trim(); // phần tử thứ hai là giá trị
                    this[key] = value; // lưu cặp khóa-giá trị này lại sử dụng phép toán indexing
                    // cũng có thể viết theo kiểu khác, trực tiếp sử dụng biến _pairs
                    // pairs[key] = value;
                }
            }
        }

    }
}
