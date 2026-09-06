# URL Shortening Service

A REST API that shortens long URLs into unique short codes and redirects to the original URL when visited.  
Uzun URL-ləri unikal qısa kodlara çevirən və qısa koda daxil olduqda orijinal URL-ə yönləndirən REST API.

---

## Features / Xüsusiyyətlər

- Accepts a long URL and generates a unique short code.  
  Uzun URL qəbul edir və unikal qısa kod yaradır.

- Redirects from the short code to the original URL.  
  Qısa koddan orijinal URL-ə yönləndirir.

- Validates that the submitted URL is a well-formed `http`/`https` address.  
  Göndərilən URL-in düzgün formatlı `http`/`https` ünvanı olduğunu yoxlayır.

- Returns the existing short code if the same URL is submitted again, instead of creating a duplicate.  
  Eyni URL təkrar göndərildikdə, yeni qeyd yaratmaq əvəzinə mövcud qısa kodu qaytarır.

---

## What I Learned / Öyrəndiklərim

- How to implement HTTP redirects in ASP.NET Core with a route-level override.  
  ASP.NET Core-da route-səviyyəli override ilə HTTP redirect necə tətbiq edilir.

- How to validate URLs using `Uri.TryCreate` instead of manual string checks.  
  Manual string yoxlamaları əvəzinə `Uri.TryCreate` istifadə edərək URL-lər necə validasiya edilir.

---

## Tech Stack / Texnologiyalar

C#, ASP.NET Core, Entity Framework Core, SQL Server

---

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| POST | `/api/urls` | Creates a short URL for the given long URL. / Verilmiş uzun URL üçün qısa URL yaradır. |
| GET | `/{shortCode}` | Redirects to the original URL. / Orijinal URL-ə yönləndirir. |

### Example Response / Nümunə Cavab

```json
"https://localhost:7085/aB3xZ"
```

---

## Setup / Quraşdırma

1. Clone the repository.  
   Repozitorini kopyalayın.

2. Make sure SQL Server LocalDB is installed.  
   SQL Server LocalDB-nin quraşdırıldığına əmin olun.

3. Apply the database migrations.  
   Veritabanı miqrasiyalarını tətbiq edin.

    `dotnet ef database update`

4. Run the project.  
   Proyekti işə salın.

    `dotnet run`
