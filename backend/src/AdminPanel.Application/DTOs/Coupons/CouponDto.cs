namespace AdminPanel.Application.DTOs.Coupons;

public record CouponDto(
    Guid Id,
    string Code,
    string Description,
    string Type,
    decimal Value,
    decimal? MinimumOrderValue,
    int? MaxUsageCount,
    int UsageCount,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive,
    Guid? RestaurantId,
    string? RestaurantName,
    DateTime CreatedAt
);
