## 🔹 Loyihaning maqsadi
Zoom uchrashuvlaridagi qatnashuvchilarni boshqarish va ma’lumotlarni qulay tarzda ko‘rish. Foydalanuvchi Excel fayldan qatnashuv ma’lumotlarini yuklab olib, ularni qidirish, filterlash va statistikalarini ko‘rish imkoniyatiga ega bo‘ladi.

---

## 🔹 Asosiy xususiyatlar
- 👥 Barcha qatnashuvchilar ro‘yxatini ko‘rish  
- 🔍 Ism yoki email bo‘yicha qidirish  
- 🎫 Faqat mehmonlarni ko‘rish  
- 🕒 Kutish zalidagi qatnashuvchilarni ko‘rish  
- ⏱ Davomiyligi 1 minut bo‘lganlarni ko‘rish  
- 🏆 Eng ko‘p qatnashganlarni aniqlash  
- 📊 Qatnashuvchilar sonini ko‘rish  
- ❌ Excelga saqlash yo‘q  

---

## 🔹 Arxitektura

### Servislar roli
- **ExcelContext** – Excel fayldan raw ma’lumotni o‘qish  
- **ExternalAttendanceService** – tashqi ma’lumotni service layerga uzatish  
- **AttendanceService** – barcha biznes logikani bajarish (filter, search, sort, statistika)  

---

## 🔹 Foydalanish
1. Excel faylni loyihaga yuklash  
2. Dastur ishga tushganda menyudan kerakli amallarni tanlash  
3. Natijalarni konsolda ko‘rish  

---

---

## 🔹 Texnologiyalar
- C# / .NET  
- Excel fayllar bilan ishlash (EPPlus yoki ClosedXML)  
- Konsol ilova  

---

## 🔹 License
MIT License


## 🔹 Folder structure (recommended)
