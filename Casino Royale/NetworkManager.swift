//
//  NetworkManager.swift
//  Casino Royale
//
//  Created by Pasha on 31.10.2021.
//

import Foundation


class NetworkManager {
    
    public static func fetchData(complition: @escaping (GameResult) -> Void){
        
        let url = URL(string: "http://95.217.177.249/casino/playMt?id=14308&bet=1&number=1092258831")!
        var request = URLRequest(url: url)

        let sema = DispatchSemaphore(value: 0)
        request.setValue("application/json", forHTTPHeaderField: "Content-Type")

        let task: Void = URLSession.shared.dataTask(with: url) { data, response, error in
            if let data = data {
                if let gameResult = try? JSONDecoder().decode(GameResult.self, from: data) {
                    complition(gameResult)
                } else {
                    print("Invalid Response")
                }
            } else if let error = error {
                print("HTTP Request Failed \(error)")
            }
            sema.signal()
        }.resume()
        sema.wait()
    }
    
}
