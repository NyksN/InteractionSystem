# LLM Kullanım Dokümantasyonu

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 2 |
| Kullanılan araçlar | Gemini 3 Pro |
| En çok yardım alınan konular | Mimari Tasarım, Coding Conventions Kontrolü |
| Tahmini LLM ile kazanılan süre | 2.5 - 3 saat |

---

## Prompt 1: Proje Kurulumu ve Klasör Mimarisi

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-29 23:45

**Prompt:**
```
Bu dosyada belirtilen proje yapısına ve Convention kurallarına tam uyum sağlamak istiyorum. Bana oluşturmam gereken klasör hiyerarşisini ve Assets altındaki düzeni liste halinde verir misin? Ayrıca proje standartlarını kaçırmamak için bir checklist oluştur.
```

**Alınan Cevap (Özet):**
```
Case dokümanındaki zorunlu klasör yapısı (Scripts/Runtime/Core vb.) ve Docs klasörüne konulması gereken dosyalar listelendi. Naming convention'a uygun klasör isimlendirmeleri (PascalCase) ile bir ağaç yapısı sunuldu.
```

**Nasıl Kullandım:**
- [x] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> Projenin temelini atarken klasör isimlendirme hataları veya eksik dosya konumu gibi basit hatalarla puan kaybetmemek için, standartları analiz ettirip temiz bir başlangıç yapmayı tercih ettim.


**Yapılan Değişiklikler (adapte ettiyseniz):**
> [LLM cevabını nasıl değiştirdiğinizi açıklayın]


## Prompt 2: Core Interface ve InteractionDetector Tasarımı

**Araç:** Gemini 3 Pro
**Tarih/Saat:** 2026-01-30 00:05

**Prompt:**
```
IInteractable adında, InteractionType (Hold, Instant, Toggle) enum'ı içeren bir interface tasarla bunun yanında InteractionDetector adında, Raycast ile nesneleri algılayan, menzil kontrolü yapan veri gönderen bir script yaz.

```

**Alınan Cevap (Özet):**
```
SOLID prensiplerine uygun, XML dokümantasyonları olmayan bir Interface ve Raycast logic'i içeren Detector scripti sağlandı.
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> Temel Raycast mantığını tekrar yazmak yerine taslağı alıp, kendi UI sistemime (InteractionUI) entegre ettim.

**Yapılan Değişiklikler (adapte ettiyseniz):**
> Door scriptinde "Anahtar yoksa kilidi aç" mantığı hatalıydı null hatası vermiyordu ve kapı yinede açılıyordu, düzelttim.
---



## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. Standartlara Uyum: Özellikle `m_` prefixleri ve XML Documentation gibi unutulabilecek angarya işleri hatasız yaptı.
2. **Mimari Tasarım: Klasör yapısı ve Interface ayrımı konusunda zaman kazandırdı.


### LLM'in Yetersiz Kaldığı Alanlar
1. [Oyun Mantığı - hala mantık kuramıyor]


### LLM Kullanımı Hakkında Düşüncelerim
> Bu case boyunca LLM kullanarak neler öğrendiniz? : Asistana sahip olduğumu
> LLM'siz ne kadar sürede bitirebilirdiniz? : 2 saat eklerdi en az 
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz? : Yerel "Ai" lar kurarak daha hızlı ve ram şişmeden hızlıca kullanabilirim. Promptlarımı geliştirerek daha sonuç odaklı cevaplar alabilirim.

---



*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
