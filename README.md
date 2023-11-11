
## About
**ENG**

Simple work for the university on the topic "Cryptography". 
There are many different encryption algorithms that could be implemented in the work, but there was no desire to implement <strike>useless</strike>, outdated algorithms. 
Therefore, AES was chosen for the implementation of the symmetric algorithm, and RSA was chosen for the asymmetric one. Algorithms were used from System.Cryptography. 
Also, in addition to AES and RSA, there was a desire to study and implement: 
- the MVVM architectural pattern 
- the Dependency injection design pattern
- unit testing 
- practice in Object-Oriented programming 
- practice in asynchrony 
____
**RU**

Курсовая работа для университета на тему «Криптография».  Никаких требований для проекта, кроме предпочтительного языка и формата, а именно настольного приложения, предъявлено не было, поэтому, его содержание определялось автором. 
Существует множество различных алгоритмов шифрования, которые можно было реализовать в работе, но реализовывать <strike>бесполезные</strike> устаревшие и неиспользуемые в настоящих проектах алгоритмы, желания не было, т.к. изучены они были в лабораторных работах. 
Поэтому для реализации симметричного алгоритма был выбран AES, а для асимметричного RSA. Изобретать велосипед тоже не хотелось поэтому использовались уже готовые алгоритмы из System.Cryptography. 
Также помимо знакомства с AES и RSA, было желание изучить и реализовать:
- архитектурный паттерн MVVM
- шаблон проектирования Dependency injection
- модульное тестирование
- попрактиковаться в ООП и асинхронности

## Documentation

### Methods:
#### AES
**ENG**
- **-** **`AES.AESEncrypt(string openText)`** **`Task<(string cipherText, string Key, string IV)>`** -  Encrypts data with AES algorithm.
- **-** **`AES.AESDecrypt(string cipherText, string Key, string IV)`** **`Task<string>`** - Decrypts data with AES algorithm.

**RU**
- **-** **`AES.AESEncrypt(string openText)`** **`Task<(string cipherText, string Key, string IV)>`** - Шифрует открытый текст алгоритмом AES, возвращает зашифрованый текст, сгенерированый ключ и вектор инициализации.
- **-** **`AES.AESDecrypt(string cipherText, string Key, string IV)`** **`Task<string>`** - Расшифровывает алгоритмом AES шифр-текст, возвращает расшифрованный текст.
___
#### RSA
**ENG**
- **-** **`RSA.RSAEncrypt(string openText, bool DoOAEPPadding)`** **`Task<(string cipherText, string PublicKey, string PrivateKey)>`** - Encrypts data with RSA algorithm.
- **-** **`RSA.RSADecrypt(string DataToDecrypt, string privateKey, bool DoOAEPPadding)`** **`Task<string>`** - Decrypts data with RSA algorithm.

**RU**
- **-** **`RSA.RSAEncrypt(string openText, bool DoOAEPPadding)`** **`Task<(string cipherText, string PublicKey, string PrivateKey)>`** - Шифрует открытый текст алгоритмом RSA, возвращает зашифрованый текст, открытый и закрытый ключ.
- **-** **`RSA.RSADecrypt(string DataToDecrypt, string privateKey, bool DoOAEPPadding)`** **`Task<string>`** - Расшифровывает алгоритмом RSA шифр-текст, возвращает расшифрованный текст.
___
#### Hash
**ENG**
- **-** **`Hash.SHA1(string data)`** **`Task<string>`** - Computes the hash of data using SHA1 algorithm.
- **-** **`Hash.SHA256(string data)`** **`Task<string>`** - Computes the hash of data using SHA256 algorithm.
- **-** **`Hash.SHA384(string data)`** **`Task<string>`** - Computes the hash of data using SHA384 algorithm.
- **-** **`Hash.SHA512(string data)`** **`Task<string>`** - Computes the hash of data using SHA512 algorithm.
- **-** **`Hash.MD5(string data)`** **`Task<string>`** - Computes the hash of data using MD5 algorithm.

**RU**
- **-** **`Hash.SHA1(string data)`** **`Task<string>`** - Возвращает хэш, вычисленный алгоритмом SHA1.
- **-** **`Hash.SHA256(string data)`** **`Task<string>`** - Возвращает хэш, вычисленный алгоритмом SHA256.
- **-** **`Hash.SHA384(string data)`** **`Task<string>`** - Возвращает хэш, вычисленный алгоритмом SHA384.
- **-** **`Hash.SHA512(string data)`** **`Task<string>`** - Возвращает хэш, вычисленный алгоритмом SHA512.
- **-** **`Hash.MD5(string data)`** **`Task<string>`** - Возвращает хэш, вычисленный алгоритмом MD5.
