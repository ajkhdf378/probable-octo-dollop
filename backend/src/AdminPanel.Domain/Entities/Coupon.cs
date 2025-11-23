using AdminPanel.Domain.Common;
using AdminPanel.Domain.Enums;

namespace AdminPanel.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; private set; }
    public string Description { get; private set; }
    public CouponType Type { get; private set; }
    public decimal Value { get; private set; }
    public decimal? MinimumOrderValue { get; private set; }
    public int? MaxUsageCount { get; private set; }
    public int UsageCount { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; }
    public Guid? RestaurantId { get; private set; }
    public Restaurant? Restaurant { get; private set; }

    private Coupon() { }

    public Coupon(
        string code,
        string description,
        CouponType type,
        decimal value,
        DateTime startDate,
        DateTime endDate,
        decimal? minimumOrderValue = null,
        int? maxUsageCount = null,
        Guid? restaurantId = null)
    {
        Code = code.ToUpperInvariant();
        Description = description;
        Type = type;
        Value = value;
        StartDate = startDate;
        EndDate = endDate;
        MinimumOrderValue = minimumOrderValue;
        MaxUsageCount = maxUsageCount;
        RestaurantId = restaurantId;
        IsActive = true;
        UsageCount = 0;
    }

    public void Update(
        string description,
        CouponType type,
        decimal value,
        DateTime startDate,
        DateTime endDate,
        decimal? minimumOrderValue,
        int? maxUsageCount)
    {
        Description = description;
        Type = type;
        Value = value;
        StartDate = startDate;
        EndDate = endDate;
        MinimumOrderValue = minimumOrderValue;
        MaxUsageCount = maxUsageCount;
        UpdateTimestamp();
    }

    public bool CanBeUsed(decimal orderValue)
    {
        if (!IsActive || IsDeleted)
            return false;

        if (DateTime.UtcNow < StartDate || DateTime.UtcNow > EndDate)
            return false;

        if (MaxUsageCount.HasValue && UsageCount >= MaxUsageCount.Value)
            return false;

        if (MinimumOrderValue.HasValue && orderValue < MinimumOrderValue.Value)
            return false;

        return true;
    }

    public void IncrementUsage()
    {
        UsageCount++;
        UpdateTimestamp();
    }

    public void Activate()
    {
        IsActive = true;
        UpdateTimestamp();
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdateTimestamp();
    }

    public decimal CalculateDiscount(decimal orderValue)
    {
        if (!CanBeUsed(orderValue))
            return 0;

        return Type == CouponType.Percentage
            ? orderValue * (Value / 100)
            : Value;
    }
}
