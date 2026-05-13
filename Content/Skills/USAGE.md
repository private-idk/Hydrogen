# Создание умения
1. Заходим в StatID и создаем числовую константу, присвоив ей номер предыдущией + 1
```c#
// Последняя
public const int Forging = 0;

// Новая
public const int Farming = 1;
```

2. Создаем класс, называя его по принципу `%StatName%Stat`, например `FarmingStat`

3. Наследуем класс от StatBase, реализуя его, например:
```c#
public class FarmingStat : StatBase
{
    public override int Id => StatID.Farming;

    public override string Name => Language.GetTextValue("Mods.Hydrogen.Stats.Farming");

    public override int Level {get;set;} = 1;

    public override int MaxLevel => 25;
}
```