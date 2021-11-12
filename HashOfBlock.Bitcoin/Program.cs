// https://en.bitcoin.it/wiki/Block_hashing_algorithm

using System.Globalization;
using System.Security.Cryptography;
using System.Text;

SHA256 sha256 = SHA256.Create();

// https://www.blockchain.com/ru/btc/block/00000000000000001e8d6829a8a21adc5d38d0a473b144b6765798e61f98bd1d
// https://btc.com/btc/block/00000000000000001e8d6829a8a21adc5d38d0a473b144b6765798e61f98bd1d

// Данные блока.
string version = "01000000";
string PrevHash = "81cd02ab7e569e8bcd9317e2fe99f2de44d49ab2b8851ba4a308000000000000";
string MerkleRoot = "e320b6c2fffc8d750423db8b1eb942ae710e951ed797f7affc8892b0f1fc122b";
string Time = "c7f5d74d";
string Bits = "f2b9441a";
string Nonce = "42a14695";

// Конкатенация данных.
var data = Hex2Binary(version + PrevHash + MerkleRoot + Time + Bits + Nonce);

// Вычисление хеша.
var hash1 = sha256.ComputeHash(data);
var hash2 = sha256.ComputeHash(hash1);

// Реверсирование массива.
var reverse = hash2.Reverse().ToArray();

// Конвертирование в шестанцатиричный формат.
string hex = BitConverter.ToString(reverse).Replace("-", string.Empty).ToLower();
Console.WriteLine(hex);


static byte[] Hex2Binary(string hex)
{
    var chars = hex.ToCharArray();
    var bytes = new List<byte>();
    for (int index = 0; index < chars.Length; index += 2)
    {
        var chunk = new string(chars, index, 2);
        bytes.Add(byte.Parse(chunk, NumberStyles.AllowHexSpecifier));
    }
    return bytes.ToArray();
}
