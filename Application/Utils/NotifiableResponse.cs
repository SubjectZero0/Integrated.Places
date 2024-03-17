﻿namespace Application.Utils
{
    public record NotifiableResponse<Tvalue>(Tvalue? Value) where Tvalue : class { };
}