using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class BasePage
    {
        public static IPage _page;

        public BasePage(IPage page) {
            _page = page;
        }
    }
}
