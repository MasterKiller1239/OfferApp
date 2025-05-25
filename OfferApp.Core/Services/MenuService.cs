using OfferApp.Core.DTO;
using OfferApp.Core.Entities;
using OfferApp.Core.Mappings;

namespace OfferApp.Core.Services
{
    internal sealed class MenuService : IMenuService
    {
        private readonly IEnumerable<Menu> _menus;

        public MenuService(IEnumerable<MenuDto> menuDtos)
        {
            var menus = new List<Menu>();
            foreach (var menu in menuDtos)
            {
                menus.Add(menu.AsEntity());
            }
            _menus = menus;
        }

        public IEnumerable<MenuDto> GetMenus() => _menus.Select(menu => menu.AsDto());
        public MenuDto? GetMenuById(int id) => _menus.FirstOrDefault(m => m.Id == id)?.AsDto();
    }
}
