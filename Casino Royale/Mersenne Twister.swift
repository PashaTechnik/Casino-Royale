//
//  Mersenne Twister.swift
//  Casino Royale
//
//  Created by Pasha on 14.11.2021.
//

import Foundation

class RandomMersenne {
    var MERS_N = 624;
    var MERS_M = 397;
    var MERS_U = 11;
    var MERS_S = 7;
    var MERS_T = 15;
    var MERS_L = 18;
    var MERS_A: UInt = 0x9908B0DF;
    var MERS_B = 0x9D2C5680;
    var MERS_C = 0xEFC60000;
    
    var mt = [UInt](repeating: 0, count: 624)
    var mti: UInt!

    private init() { }
    
    public init(_ seed: UInt) {
        RandomInit(seed);
    }
    
    public func RandomInit(_ seed: UInt)
    {
        mt[0] = seed;
        for mti in 1..<MERS_N {
            
            mt[mti] = (mt[mti - 1] ^ (mt[mti - 1] >> 30))
            mt[mti] = 1812433253 * mt[mti]
            mt[mti] =  mt[mti] + UInt(mti)
        }
    }
    
    public func BRandom() -> UInt {
        var y: UInt
        
        if mti >= MERS_N {
            let LOWER_MASK: UInt = 2147483647
            let UPPER_MASK: UInt = 0x80000000
            var mag01: [UInt] = [0, MERS_A]

            var kk: Int = 0
            
            for kk in 0..<(MERS_N - MERS_M) {
                y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK)
                mt[kk] = mt[kk + MERS_M] ^ (y >> 1) ^ mag01[Int(y) & 1]
            }
            
            for _ in 0..<(MERS_N - 1) {
                y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK)
                mt[kk] = mt[kk + (MERS_M - MERS_N)] ^ (y >> 1) ^ mag01[Int(y) & 1]
            }


            y = (mt[MERS_N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK)
            mt[MERS_N - 1] = mt[MERS_M - 1] ^ (y >> 1) ^ mag01[Int(y) & 1]
            mti = 0
        }
        
        mti = mti + 1
        y = mt[Int(mti)];

        // Tempering (May be omitted):
        y ^= y >> MERS_U
        y ^= (y << MERS_S) & UInt(MERS_B)
        y ^= (y << MERS_T) & UInt(MERS_C)
        y ^= y >> MERS_L
        return y
    }
    
    
    
}

extension Bool {
    static func ^ (left: Bool, right: Bool) -> Bool {
        return left != right
    }
}
