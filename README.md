# Rightway-Games-Test-Task
## Доработки базовой архитектуры
### Модули кораблей
Я решил упразднить компонент ShipController и его наследников, а также убрал сериализацию WeaponSystem и MovementSystem из класса Spaceship. 
Spaceship стал представлять собой композицию из объектов, реализующих IShipSystem и IShipProcess.
IShipSystem - модуль космического корабля. В интерфейсе есть единственный метод Init для начальной инициализации. 
Мы можем собирать наш корабль из различных компонентов, реализующих этот интерфейс. 
IShipProcess - небольшая оптимизация для уменьшения количества Update в компонентах. Это может быть полезно при большом количестве кораблей на поле.
Я заметил, что в ShipController в своём Update вызывал методы из WeaponSystem и MovementSystem, меня натолкнуло это на создание этого интерфейса.
##### Почему так?
При первоначальном подходе мы можем натолкнуться на проблему с наследованием. Если Spaceship будет знать о своих модулях напрямую, 
то когда мы захотим добавлять новые модули для кораблей нам придётся либо создавать огромное количество его наследников 
(SpaceshipWithWeapons, SpaceShipWithWeaponsAndArmor и т.д.), либо запихнуть все модули в Spaceship и проверять каждую ссылку на null.
В моём варианте, Spaceship - композиция. Мы можем вешать сколько угодно систем на корабль, составлять различные комбинации из них, 
при этом вообще не прикасаясь к основному компоненту. 
Игровые объекты, по типу бонусов и снарядов, будут воздействовать на конкретные модули через интерфейсы. Также модули обособлены друг от друга, 
у них только одна задача. Их будет очень легко тестировать с помощью Unit-тестов.
### MovementSystem
Я решил совсем отделить MovementSystem от всех других компонентов. Теперь класс MovementSystem - базовый класс для всех компонентов, 
описывающих движение объектов по игровому полю. Также все игровые объекты, например Projectile, больше не отвечают за их движение, а только лишь за логику снаряда. 
##### Почему так?
Снова проблема с наследованием. Пример: геймдизайнер захотел, чтобы LaserBeamы имели разные траектории по полю: либо по прямой, либо по дуге с каким-нибудь Ease.
Либо раздуваем LaserBeam, делаем выбор в инспекторе, либо куча наследников. А что делать с другими типами снарядов?
При моём варианте делаем разные MovementSystem и вешаем на объекты, которые подразумевают движение. Если хотим, чтобы снаряд двигался по прямой, вешаем LonLatMovementSystem,
хотим, чтобы по дуге ArcMovementSystem и т.д. Легко расширяется, повторное использование, единственная ответственность, легко тестируется.
## Что можно доработать?
1. Сделал быстрый вариант GameController в виде Singleton. Но сразу видно, как он может потенциально раздуться от кода. Да и синглтоны я не очень люблю. Лучше хранить в DI 
контейнере какой-нибудь объект, который будет отвечать за статистику в сессии, а общаться с ним по интерфейсу. 
2. GameAreaHelper может быть потенциально опасным, так как инициализируется через статик-конструктор. И в целом статика не очень очевидно работает, как по мне. 
Я бы также использовал объект, с ссылкой в DI контейнере. 
3. Некоторые из систем, например HealthSystem, можно переиспользовать и не на кораблях. Тут можно подумать, как лучше их отвязать от IShipSystem. Первое, что приходит
на ум - класс-адаптер для корабля, но что-то слишком много компонентов получается.

## С радостью послушаю ваш фидбек!