# dotnet_testable_code_proposal1

## 概要

* DI 等を導入してもモックの準備等テストを実施するのは大変である。
* 100% に拘らなければ実際にテストしたい複雑なロジック(if文だらけの箇所とか)は、モック等を準備しなくてもそれ単体で切り出してテストできる範囲であることが多いのではないか？
* 本リポジトリは、上記の実際にテストしたいロジックを切り出す方法の提案である。

## 補足

* クラスのインスタンス化やメソッドを実行するのに、他のクラスやパラメータの用意が大変でテストが困難なことがある。
* 対応として役割毎にクラスやメソッドを分けることが考えられるが、特定の処理に強く依存しているなど必ずしもきれいに分けられるとは限らない。
* また C# は Java の同一パッケージ内ならアクセス可能に相当する機能が無いため、テスト対象を public にするか、internal にしてテスト対象のアセンブリからテスト用のアセンブリをフレンドに設定する必要がある。
どちらもスコープが広いため、前述の強く依存するクラスやメソッドのような他の人に触れてほしくないものに適用するには抵抗がある。

  ※ 厳密にはリフレクションを用いれば public でなくても可能だが、煩雑で維持コストが高くつくため選択肢から除外している。

## 環境
```
> dotnet --info
.NET SDK:
 Version:           8.0.100
 Commit:            57efcf1350
 Workload version:  8.0.100-manifests.6c33ef20

ランタイム環境:
 OS Name:     Windows
 OS Version:  10.0.19045
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\8.0.100\

インストール済みの .NET ワークロード:
 Workload version: 8.0.100-manifests.6c33ef20
```

## 構築
```
dotnet new console -o App -n dotnet_testable_code_proposal1.App
dotnet new classlib -o Service -n dotnet_testable_code_proposal1.Service
dotnet new xunit -o ServiceTest -n dotnet_testable_code_proposal1.ServiceTest
dotnet add App reference Service
dotnet add ServiceTest reference Service
dotnet new gitignore
```

## 実行
```
dotnet run --project App
```
