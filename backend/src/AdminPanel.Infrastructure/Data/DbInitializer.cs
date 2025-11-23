using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.Data;

/// <summary>
/// Inicializador do banco de dados com dados de exemplo
/// </summary>
public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Aplicar migrations pendentes
        await context.Database.MigrateAsync();

        // Se já existir dados, não fazer seed
        if (await context.Users.AnyAsync())
            return;

        // Criar usuário admin padrão
        var adminUser = new User(
            "Administrador do Sistema",
            "admin@example.com",
            BCrypt.Net.BCrypt.HashPassword("admin123"),
            UserRole.Admin
        );

        var managerUser = new User(
            "Gerente de Operações",
            "manager@example.com",
            BCrypt.Net.BCrypt.HashPassword("manager123"),
            UserRole.Manager
        );

        var operatorUser = new User(
            "Operador de Sistema",
            "operator@example.com",
            BCrypt.Net.BCrypt.HashPassword("operator123"),
            UserRole.Operator
        );

        await context.Users.AddRangeAsync(adminUser, managerUser, operatorUser);

        // Criar restaurantes de exemplo
        var restaurant1 = new Restaurant(
            "Pizzaria Bella Napoli",
            "Autêntica pizza italiana com massa artesanal e ingredientes importados da Itália",
            "Rua das Flores, 123",
            "São Paulo",
            "SP",
            "01234-567",
            "+55 11 3333-4444",
            TimeSpan.FromHours(18),  // 18:00
            TimeSpan.FromHours(23)   // 23:00
        );
        restaurant1.UpdateLogo("https://via.placeholder.com/200x200?text=Bella+Napoli");
        restaurant1.UpdateRating(4.8m);

        var restaurant2 = new Restaurant(
            "Sushi Master",
            "Sushi e sashimi frescos preparados por mestres sushimen certificados",
            "Av. Paulista, 1000",
            "São Paulo",
            "SP",
            "01310-100",
            "+55 11 5555-6666",
            TimeSpan.FromHours(12),  // 12:00
            TimeSpan.FromHours(22)   // 22:00
        );
        restaurant2.UpdateLogo("https://via.placeholder.com/200x200?text=Sushi+Master");
        restaurant2.UpdateRating(4.9m);

        var restaurant3 = new Restaurant(
            "Churrascaria Gaúcha",
            "Rodízio de carnes nobres com buffet completo de saladas e acompanhamentos",
            "Rua dos Pampas, 456",
            "Porto Alegre",
            "RS",
            "90000-000",
            "+55 51 7777-8888",
            TimeSpan.FromHours(11),  // 11:00
            TimeSpan.FromHours(23)   // 23:00
        );
        restaurant3.UpdateLogo("https://via.placeholder.com/200x200?text=Churrascaria");
        restaurant3.UpdateRating(4.7m);

        await context.Restaurants.AddRangeAsync(restaurant1, restaurant2, restaurant3);
        await context.SaveChangesAsync();

        // Criar cupons de exemplo
        var coupon1 = new Domain.Entities.Coupon(
            "BEMVINDO10",
            "10% de desconto para novos clientes",
            CouponType.Percentage,
            10,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(3),
            minimumOrderValue: 30,
            maxUsageCount: 1000
        );

        var coupon2 = new Domain.Entities.Coupon(
            "PIZZA20",
            "R$ 20 de desconto em pizzas",
            CouponType.FixedAmount,
            20,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(1),
            minimumOrderValue: 60,
            maxUsageCount: 500,
            restaurantId: restaurant1.Id
        );

        var coupon3 = new Domain.Entities.Coupon(
            "SUSHI15",
            "15% de desconto no Sushi Master",
            CouponType.Percentage,
            15,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMonths(2),
            minimumOrderValue: 50,
            restaurantId: restaurant2.Id
        );

        await context.Coupons.AddRangeAsync(coupon1, coupon2, coupon3);
        await context.SaveChangesAsync();
    }
}
