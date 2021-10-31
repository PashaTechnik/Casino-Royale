//
//  main.swift
//  Casino Royale
//
//  Created by Pasha on 31.10.2021.
//

import Foundation


let sema = DispatchSemaphore(value: 0)

func Next(a:Int, c:Int, last: Int) -> UInt64
{
    let bigI:UInt64 = UInt64(a * last)
    var l = bigI + UInt64(c)
    let last = l % 4294967296;
    return last;
}


func getCoificientts(){
    var gameResult: GameResult
    var m: Int = 0
    NetworkManager.fetchData { GameResult in
        m = GameResult.realNumber
        sema.signal()
    }
    sema.wait()
    
    var k: Int = 0
    
    NetworkManager.fetchData { GameResult in
        k = GameResult.realNumber
        sema.signal()
    }
    sema.wait()
    
    var l: Int = 0
    
    NetworkManager.fetchData { GameResult in
        l = GameResult.realNumber
        sema.signal()
    }
    sema.wait()
    
    print(m)
    print(k)
    print(l)
    

    
    var coef1 = m - l
    var coef2 = k - m
    
    var i = (4294967296 + coef1)/coef2
    print(i)
    print(Int(i))
    
    var resVal = l - ((m*i)%4294967296)

    var y = 4294967296 + resVal
    print(y)
    print(Int(y))
    
    
    print(Next(a: y, c: i, last: l))
    

}


getCoificientts()


//197373647 = (a * 3576682619 + c) % pow(2,32)

//1511091214 = (a * 197373647 + c) % pow(2,32)

//197373647 = (3576682619 * a)%pow(2,32) + c%pow(2,32)

//197373647 = (3576682619 * a)%pow(2,32) + c%pow(2,32)


// c%pow(2,32) = 197373647 - (3576682619 * a) % pow(2,32)


// m = (k*a) % pow(2,32) + l - (a*m)%pow(2,32)
