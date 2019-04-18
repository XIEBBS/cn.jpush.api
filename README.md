# cn.jpush.api
极光推送新旧版本差异很大，特别是从1.0想升级至最新版本，基本上原有的对接要重写。
此版本就是针对旧版本升级的用户，可以无缝升级。并且支持至.NET Standard。

本版本基于官方的cn.jpush.api升级而成。
并且修改官方的版本的以下几个问题：
#1 支持uri_activity；
#2 apns_production设置false时，不生效；
