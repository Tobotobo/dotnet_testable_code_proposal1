# dotnet_testable_code_proposal1

## 概要

* DI 等を導入してもモックの準備等テストを実施するのは大変である。
* 100% に拘らなければ実際にテストしたい複雑なロジック(if文だらけの箇所とか)は、モック等を準備しなくてもそれ単体で切り出してテストできる範囲であることが多いのではないか？
* 本リポジトリは、上記の実際にテストしたいロジックを切り出す方法の提案である。

## 補足

* クラスのインスタンス化やメソッドを実行するのに、他のクラスやパラメータを用意が大変でテストが困難なことがある。
* 対応として役割毎にクラスやメソッドを分けることが考えられるが、特定の処理に強く依存しているなど必ずしもきれいに分けられるとは限らない。
* また、Java と異なり C# は テストを実行するのに対象が public である必要があるため、前述の強く依存するクラスやメソッドのような他の人に触れてほしくないものも、テストしたければ public にしなければならない。  
  ※ Java は 同一パッケージ内ならアクセスできるように設定できるが、C# は同一名前空間内なら...という設定が無い。アセンブリ単位はあるが、テスト対象のクラスとテストクラスが通常別プロジェクト＝別アセンブリになる C# では実質 public にするしかない。
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
