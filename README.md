# Delivery Order System


## Задание:

[Тестовое задание в Versta](https://versta.io/hr/testfordevjun)


## Предварительные требования

Должны быть установлены все следующие компоненты:
- **Docker**: Необходим для работы с контейнерами базы данных.
- **.NET SDK 8.0.302**: Необходим для запуска бэкенд-сервера. Скачать можно [здесь](https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0).


## Настройка среды

Для корректной работы .NET убедитесь, что установленные компоненты доступны в вашей командной оболочке. Для этого попробуйте запустить команду ```dotnet --version```. Если выведется версия, то все уже настроено, если нет, то нужно добавить пути к .NET в переменную среду PATH терминала. На маке это можно сделать прописав следующие команды в терминал:

```shell
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$HOME/.dotnet
source ~/.zshrc
```

## Запуск проекта


### Запуск базы данных

1. Перейдите в директорию с `docker-compose.yaml`:
    ```shell
    cd ~/delivery-order-system/DeliveryOrderSystem.Backend/DeliveryOrderSystem
    ```
2. Запустите Docker контейнер:
    ```shell
    docker-compose up --build
    ```

### Запуск бэкенда

1. Откройте новую консоль и перейдите в директорию с `Program.cs`:
    ```shell
    cd ~/delivery-order-system/DeliveryOrderSystem.Backend/DeliveryOrderSystem
    ```
2. Соберите и запустите проект:
    ```shell
    dotnet build
    dotnet run
    ```

Бэкенд запустится на порту 8000, и начнется процесс миграций базы данных.


### Запуск фронтенда

1. Перейдите в директорию фронтенд-проекта:
    ```shell
    cd ~/delivery-order-system/delivery-order-system.frontend
    ```
2. Установите зависимости:
    ```shell
    npm install
    ```
3. Запустите фронтенд:
    ```shell
    npm run dev
    ```

Фронтенд будет доступен по адресу: [http://localhost:5174](http://localhost:5174).

## Примечания

Поскольку база данных изначально не содержит данных, список заказов на сайте будет пуст до добавления новых заказов.

## То, как выглядит веб-приложение можно по [ссылке](https://disk.yandex.ru/i/YeOx18LB4cJc2Q) 
