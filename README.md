[![Release](https://img.shields.io/github/v/release/flareoNNN/YoutubeSearch "Release")](https://github.com/flareoNNN/YoutubeSearch/releases "Release")
[![License](https://img.shields.io/github/license/flareoNNN/YoutubeSearch "License")](https://github.com/flareoNNN/YoutubeSearch/blob/master/LICENSE "License")

# YoutubeSearch

C# için yazılmış YouTube arama ve video bilgisi çekme kütüphanesi.<br>
Versiyon: *1.0.0*

# Kurulum

YoutubeSearch Link: [https://github.com/flareoNNN/YoutubeSearch/releases/download/v1.0.0/YoutubeSearch.dll](https://github.com/flareoNNN/YoutubeSearch/releases/download/v1.0.0/YoutubeSearch.dll)<br><br>

YoutubeSearch'ı visual studio'da projenize girerek references(başvurular) kısmından .dll dosyası olarak ekleyebilirsiniz. Herhangi bir arama işlemi için aşağıdaki kullanım örneğine göz atabilirsiniz.

# Kullanım

````c#
using System;
using YoutubeSearch;

namespace pluginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new VideoSearch();

            foreach (var item in items.Search("Ezhel"))
            {
                Console.WriteLine(item.Title + " - " + item.Url + " - " + item.ViewCount + " - " + item.Author);
            }

            Console.ReadKey();
        }
    }
}
````

Çıktı:
````
Ezhel - Bul Beni - https://www.youtube.com/watch?v=sxVYkUVtih4 - 39914665 - Ezhel
Ezhel - Mayrig - https://www.youtube.com/watch?v=T1L3R7Zon1U - 2656042 - Ezhel
Ezhel - Mayrig (Live) - https://www.youtube.com/watch?v=oetvIAiNugU - 3006443 - Ezhel
Ezhel - Sakatat - https://www.youtube.com/watch?v=ciziKqoYJqY - 17514148 - Ezhel
Murda & Ezhel - Bi Sonraki Hayatimda Gel (prod. Spanker) [Lyric video] - https://www.youtube.com/watch?v=tiEt1qkaaGA - 220417425 - Murda
Ezhel - Sakatat (Live) - https://www.youtube.com/watch?v=qGhwqeMZmKQ - 632397 - Ezhel
Ezhel & Kelvyn Colt - End of Time [Behind The Scenes] - https://www.youtube.com/watch?v=a8lxV7BQ8NU - 131958 - Ezhel
Ezhel & Kelvyn Colt - End of Time - https://www.youtube.com/watch?v=nAYDLkxBGMw - 907935 - Ezhel
Ezhel - Sakatat [Behind The Scenes] - https://www.youtube.com/watch?v=FMn3k3QQR30 - 550176 - Ezhel
Ezhel & Kelvyn Colt - LINK UP [Official Video] (prod. by Lucry & Suena) - https://www.youtube.com/watch?v=vR_tnn6En3o - 6725892 - Ezhel
````

# Desteklenen Öğeler

````
Video Başlığı
Video Kanal İsmi
Video Görüntülenme Sayısı
Video Süresi
Video URL
Video Thumbnail
````

# Lisans

Apache License 2.0
