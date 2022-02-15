# 水とUnlitシェーダーとDepth of Field

ポストプロセスの被写界深度効果(Depth of Field)を使うと、水面のような半透明ものや影がないUnlitシェーダーが正常に描かれない場合があります。このリポジトリーではその解決策をまとめます。

![ぼやけるキューブ](Recordings/image_001.jpg)

## 動作環境
- Unity2020.3.9f1
- PostProcessing Stack Ver3.1.1
- LowPoly Water Ver1.0.0


## プロジェクトの準備
1. このプロジェクトを任意の場所にダウンロードして展開したり、クローンしてください
1. Unityで開きます
1. Package Managerから [Ebru Dogan. LowPoly Water](https://assetstore.unity.com/packages/tools/particles-effects/lowpoly-water-107563) をインポートします。折角なので好評価も是非
1. ProjectウィンドウからAssets > WaterUnlitDOF > Scenesフォルダーを開きます
1. DemoSceneExが開始時の不具合があるシーン、DemoSceneExFixが解決させたシーンです


# 使用アセット
- [Ebru Dogan. LowPoly Water](https://assetstore.unity.com/packages/tools/particles-effects/lowpoly-water-107563)
- PostProcessing Stack
