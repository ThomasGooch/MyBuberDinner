# MyBuberDinner

MyBuberDinner is a simple dinner party app, developed by the amazing Amichai Mantinband, and this is my study of clean architecture. I can see use of CRQS, Dependency Inversion, EFcore, and more.

## Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "password":"Passw0rd!"
}
```

#### Register Response
```js
200 Ok
```

```json
{
    "id":"d89...-...-...-...194",
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "token":"eyjhb...x0y"
}
```

## Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email":"TomMooch@email.com",
    "password":"Passw0rd!"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id":"d89...-...-...-...194",
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "token":"eyjhb...x0y"
}
```


## Dinner API