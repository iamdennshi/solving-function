using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SolveWebApp.Model;
using System.Globalization;

namespace SolveWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        // Добавляем атрибут к свойству, чтобы связать его с формой
        [BindProperty]
        public Data data { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            // Установить локаль 'en' чтобы тип double мог преоброзовать значение с . пришедшее из формы
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            _logger = logger;
        }
        // Вызывается при загрузки представления
        public void OnGet()
        {
            data = new Data();
        }
        // Вызывается при отправлке формы из представления
        public IActionResult OnPost()
        {
            // Конвертирование полученных значений из формы
            data.xn = Convert.ToDouble(Request.Form["data.xn"]);
            data.xk = Convert.ToDouble(Request.Form["data.xk"]);
            data.xh = Convert.ToDouble(Request.Form["data.xh"]);
            data.a = Convert.ToDouble(Request.Form["data.a"]);

            // Длина массива для точек и значений функции в этих точках
            int length = Convert.ToInt32((data.xk - data.xn) / data.xh) + 1;

            data.x = new Double[length];
            data.y = new Double[length];

            for (int i = 0; i < length; i++)
            {
                data.x[i] = Math.Round(data.xn + data.xh * i, 1);
                if (data.x[i] <= 0)
                {
                    data.y[i] = Data.f1(data.x[i]);
                }
                else if (0 < data.x[i] && data.x[i] <= data.a)
                {
                    data.y[i] = Data.f2(data.x[i]);
                }
                else if (data.x[i] > data.a)
                {
                    data.y[i] = Data.f3(data.x[i]);
                }
            }
            return Page();
        }
    }
}