namespace AdminPanel.Application.DTOs.Coupons;

public record CreateCouponDto(
    string Code,
    string Description,
    string Type,
    decimal Value,
    DateTime StartDate,
    DateTime EndDate,
    decimal? MinimumOrderValue,
    int? MaxUsageCount,
    Guid? RestaurantId
);
