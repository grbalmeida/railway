module Operators

open System

let (^) firstString secondString =
    sprintf "%s%s" firstString secondString

let (!!) string = String.IsNullOrEmpty string

let (<~) (string : string) substring =
    (!!substring || string.Contains substring)