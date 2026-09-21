# Etap 6 — Dependency Injection

## Zadanie 13 — migracja CustomerService do Dependency Injection

W istniejącej aplikacji znajdź miejsca, w których `CustomerService` jest tworzony bezpośrednio, np.:

```csharp
var service = new CustomerService();
```

lub:

```csharp
private readonly CustomerService service =
    new CustomerService();
```

Zrefaktoruj aplikację tak, aby `CustomerService` był dostarczany przez mechanizm Dependency Injection, zamiast być tworzony za pomocą `new`.

### Wymagania

- Znajdź wszystkie miejsca, w których aplikacja samodzielnie tworzy `CustomerService`.
- Zarejestruj `CustomerService` w kontenerze DI jako usługę Scoped.
- W komponentach Blazor pobieraj `CustomerService` przez DI.
- Usuń wszystkie wystąpienia `new CustomerService()`.
- Nie zmieniaj zachowania aplikacji — lista klientów, dodawanie, edycja i usuwanie powinny nadal działać.

### Po refaktoryzacji

Kod w stylu:

```csharp
var service = new CustomerService();
var customers = await service.GetAllAsync();
```

powinien zostać zastąpiony wykorzystaniem serwisu dostarczonego przez DI.

### Zastanów się

- Gdzie w aplikacji Blazor rejestrujemy serwisy?
- Jak zarejestrować usługę jako Scoped?
- Jak wstrzyknąć usługę do komponentu `.razor`?
- Kto po zmianie odpowiada za utworzenie instancji `CustomerService`?
- Co się stanie, jeśli spróbujesz wstrzyknąć usługę, której nie zarejestrowano?

### Warunek ukończenia

W komponentach aplikacji nie występuje już `new CustomerService()`, a wszystkie dotychczasowe funkcjonalności nadal działają.

## Zadanie 14 — wprowadzenie ICustomerService

Zrefaktoruj istniejącą aplikację tak, aby komponenty korzystały z `ICustomerService`, zamiast bezpośrednio z `CustomerService`.

### Wymagania

1. Utwórz interfejs `ICustomerService`.
2. Przenieś do niego kontrakt operacji wykorzystywanych przez aplikację, np.:

```csharp
public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetAsync(int id);
    Task CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
```

Jeśli lista korzysta już z paginacji, interfejs powinien zawierać też `GetPageAsync`.
3. `CustomerService` powinien implementować `ICustomerService`.
4. Zmień konfigurację DI tak, aby dla `ICustomerService` dostarczany był `CustomerService`.
5. Zmień istniejące komponenty:

- `Customers.razor`
- `CustomerCreate.razor`
- `CustomerEdit.razor`

tak, aby zależały od `ICustomerService`.
6. Zachowanie aplikacji nie może się zmienić.

### Zastanów się

- Czy komponent musi wiedzieć, że implementacją jest `CustomerService`?
- Gdzie określamy, jaka implementacja zostanie użyta dla `ICustomerService`?
- Co musielibyśmy zmienić, gdybyśmy chcieli użyć `FakeCustomerService`?
- Czy wtedy trzeba byłoby modyfikować `Customers.razor`?
- Co daje nam interfejs, czego nie dawało samo `@inject CustomerService`?

