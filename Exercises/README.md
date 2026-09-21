# Ćwiczenie — migracja Customers do Blazora

Celem ćwiczenia jest przeniesienie wybranej funkcjonalności z aplikacji ASP.NET Web Forms do nowej aplikacji Blazor.

Punktem odniesienia jest istniejąca implementacja:

```
WebFormsApp
├── Customers.aspx
├── Customers.aspx.cs
├── CustomerCreate.aspx
├── CustomerCreate.aspx.cs
├── CustomerEdit.aspx
├── CustomerEdit.aspx.cs
├── CustomerDetails.aspx
└── CustomerDetails.aspx.cs
```

Nie należy przenosić kodu Web Forms 1:1. Zaimplementuj tę samą funkcjonalność, wykorzystując mechanizmy Blazora poznane podczas szkolenia.

## Przygotowanie projektu

Utwórz nową aplikację Blazor Web App o nazwie:

`BlazorApp`

Skonfiguruj aplikację do korzystania z Interactive Server.

Dodaj do projektu potrzebne modele i serwisy udostępnione w materiałach szkoleniowych, a następnie zarejestruj wymagane serwisy w kontenerze DI.

Jeśli używany podczas szkolenia szablon Blazor Web App przechowuje routowalne komponenty w `Components/Pages`, należy użyć struktury wygenerowanej przez szablon zamiast tworzyć dodatkowy katalog `Pages`.

## Etapy

1. [Etap 1 — lista i dodawanie](etap-1.md)
2. [Etap 2 — edycja i komponenty](etap-2.md)
3. [Etap 3 — stan aplikacji i preferencje użytkownika](etap-3.md)
4. [Etap 4 — JavaScript interop](etap-4.md)
5. [Etap 5 — wyszukiwanie i paginacja](etap-5.md)
6. [Etap 6 — Dependency Injection](etap-6.md)
7. [Etap 7 — migracja obsługi błędów](etap-7.md)
