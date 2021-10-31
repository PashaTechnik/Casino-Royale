//
//  File.swift
//  Casino Royale
//
//  Created by Pasha on 31.10.2021.
//

import Foundation

struct GameResult: Codable {
    var message: String
    var account: Account
    var realNumber: Int
}

struct Account: Codable {
    var id: String
    var money: Int
    var deletionTime: String
}
