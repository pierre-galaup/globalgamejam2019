public static class Constants
{
    // Initial player values

    public const int InitialMoney = 250;
    public const int InitialPlayerHealthPoint = 100;
    public const int InitialAmmoNumber = 30;
    public const int InitialDamagesPerFire = 30;
    public const float InitialFireRate = 3f;

    // Enemy initial values
    public const int InitialZombieHealth = 30;
    public const int InitialZombieMoneyValue = 10;
    public const int InitialZombieDamages = 10;

    public static int ZombieHealthCalculator(int dayPassed)
    {
        return (int) (InitialZombieHealth * EnemyHealthMultiplier(dayPassed));
    }

    public static int ZombieMoneyValueCalculator(int dayPassed)
    {
        return InitialZombieMoneyValue * (1 + dayPassed) / 2;
    }

    public static int ZombieDamageCalculator(int dayPassed)
    {
        return (int) (InitialZombieDamages * EnemyDamagesMultiplier(dayPassed));
    }

    public static int BonusValueCalculator(int daysPassed, int zombiesKilled)
    {
        return ((1 + daysPassed) * zombiesKilled) * 5;
    }

    private static float EnemyHealthMultiplier(int daysPassed)
    {
        return 1f + daysPassed * 0.33f;
    }

    private static float EnemyDamagesMultiplier(int daysPassed)
    {
        return 1f + daysPassed * 0.33f;
    }

    // Shop values

    public static int UpgradeHpCostCalculator(int currentValue)
    {
        return currentValue * 2;
    }

    public static int UpgradeHpCalculator(int currentValue)
    {
        return (int) (currentValue * 1.1);
    }

    public static int UpgradeAmmoCostCalculator(int currentValue)
    {
        return currentValue * 4;
    }

    public static int UpgradeAmmoCalculator(int currentValue)
    {
        return (int) (currentValue * 1.3);
    }

    public static int UpgradeDamageCostCalculator(int currentValue)
    {
        return currentValue * 6;
    }

    public static int UpgradeDamageCalculator(int currentValue)
    {
        return (int) (currentValue * 1.4);
    }

    public static int UpgradeFireRateCostCalculator(float currentValue)
    {
        return (int) (currentValue * 100);
    }

    public static float UpgradeFireRate(float currentValue)
    {
        return currentValue * 1.25f;
    }
}