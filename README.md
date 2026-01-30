# Interaction System - Ömer Boyraz

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.3.0f1 |
| Render Pipeline | Built-in |
| Case Süresi | 4 saat |
| Tamamlanma Oranı | %100 (Bonuslar Dahil: %85) |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/NyksN/InteractionSystem.git
```

2. Unity Hub'da projeyi açın
3. `Assets/LuduCase/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |
| E (Basılı Tut) | Hold Interaction |

### Test Senaryoları

1. **Door Test:**
   - Koyu renkli kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Kırmızı renkli anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin
   - Kilitli kapının tetiklendiğini görün
   - Switch Kilitli kapıyı "Force Unlock" eder

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

---

## Mimari Kararlar

```
Sistem IInteractable arayüzü ve InteractionDetector (Raycast) üzerine kuruludur.
```

**Neden bu yapıyı seçtim:**
> Bu yapıyı seçerek Player sınıfının, etkileşime geçtiği nesnenin türünü (Kapı mı, Sandık mı?) bilme zorunluluğunu ortadan kaldırdım. Bu sayede sisteme yeni bir etkileşimli nesne eklediğimde Player kodunda değişiklik yapılmasına gerek kalmadı. Raycast kullanımı ise FPS bakış açısında Trigger'a göre çok daha hassas ve doğru bir hedefleme sağladığı için kullandım.

**Alternatifler:**
> Trigger Collider: Daha basit olurdu ancak oyuncunun arkasındaki veya yanındaki nesnelerle yanlışlıkla etkileşime girmesine yol açabilirdi.

**Trade-off'lar:**
> [Bu yaklaşımın avantaj ve dezavantajları]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| Strategy| IInteractable| Her nesnenin (Door, Chest) Interact metodunu farklı yorumlaması için. |
| Observer | Switch (UnityEvents) | Switch ile tetiklenen nesneler arasındaki bağı koparmak için. |


---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / | Tüm scriptlerde uygulandı.|
| s_ prefix (private static) | [x] /|Kullanılan yerlerde uygulandı. |
| k_ prefix (private const) | [x] /| InteractionDetector vb. uygulandı.|
| Region kullanımı | [x] /| Fields, Unity Methods, Methods şeklinde ayrıldı.|
| Region sırası doğru | [x] /| Standartlara sadık kalındı.|
| XML documentation | [x] / | Tüm public API ve Interface üyelerinde mevcut.|
| Silent bypass yok | [x] / |Null referanslar için Error Log eklendi. |
| Explicit interface impl. | [ ] /| Implicit tercih edildi (Inspector erişimi kolaylığı için).|

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest, P_Switch, P_Key_Red |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood, M_Chest_Gold, M_Key_Red|
| T_ prefix (Texture) | [ ] / [ ] | |
| SO isimlendirme | [x] / [ ] | Item_RedKey|

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | Tüm prefab rootları sıfırlandı.|
| Pivot bottom-center | [x] / [ ] | Kapı ve Sandık pivotları için parent-child yapısı kuruldu.|
| Collider tercihi | [x] / [ ] | Performans için Box Collider tercih edildi. |
| Hierarchy yapısı | [x] / [ ] |Visual ve Logic objeleri ayrıldı. |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]
Standart Unity küpleriyle çalışırken Pivot noktalarını (Kapı menteşesi, Sandık kapağı) ayarlamak için hiyerarşik yapı kurmak gerekti. Ayrıca m_ prefix alışkanlığını kod yazarken sürekli kontrol etmek dikkat gerektirdi.
---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [x] / [ ] UI listesi

### Bonus (Nice to Have)

- [x] Animation entegrasyonu
- [x] Sound effects
- [?] Multiple keys / color-coded
- [x] Interaction highlight
- [ ] Save/Load states
- [x] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. Multiple keys / color-coded - Aslında mantığı hazır sadece farklı kapılar ve farklı anahtarlar eklemedim sahneyi boğmamak için.
2. Save/Load states - "Player Prefs" ile yapmak istemedim "Json" yapısı kurmak çok zamanımı alacağı için tamamlamadım.

### Bilinen Bug'lar


### İyileştirme Önerileri
1. Tween kütüphanesi (DoTween) kullanılarak animasyonlar daha elastik yapılabilir.


---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: Oyuncu bir nesneye baktığında, nesne parlayarak (Emission) görsel geri bildirim verir.
   - Neden ekledim: Oyuncunun hangi nesneyle etkileşime geçeceğini net bir şekilde anlaması için

2. **[Özellik Adı]**
   - Açıklama: Menzil dışındaki nesnelere bakıldığında UI'da "Too Far" uyarısı çıkar.
   - Neden ekledim: Oyuncunun sistemin bozuk olduğunu düşünmesini engellemek ve yaklaşması gerektiğini belirtmek için.

---

## Dosya Yapısı

```
Assets/
├── TextMeshPro/
├── LuduCase/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   ├── ItemData.cs
│   │   │   │   └── InteractionHighlight.cs
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   ├── Chest.cs
│   │   │   │   ├── Switch.cs
│   │   │   │   ├── KeyPickup.cs
│   │   │   │   └── TestInteractable.cs
│   │   │   ├── Player/
│   │   │   │   ├── InteractionDetector.cs
│   │   │   │   ├── Inventory.cs
│   │   │   │   └── SimpleFPSController.cs
│   │   │   └── UI/
│   │   │       ├── InteractionUI.cs
│   │   │       └── InventoryUI.cs
│   ├── ScriptableObjects/
│   │   ├── Items/
│   │   │   ├── Item_RedKey.asset
│   ├── Prefabs/
│   │   ├── Interactables/
│   │   ├── Player/
│   │   ├── UI/
│   ├── Materials/
│   ├── Audios/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | Ömer Boyraz |
| E-posta | omersg23@gmail.com |
| LinkedIn | https://www.linkedin.com/in/ömer-boyraz-57540122b/ |
| GitHub | [github.com/NyksN] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
