# AIBikeRobot
基于Unity ML-Agents release_15开发能够智能躲避同伴的自行车机器人

# 环境配置

1. 下载[release15](https://github.com/Unity-Technologies/ml-agents/releases/tag/release_15)后，通过 `Window` -> `Package Manager` `->Add package from disk...`，添加`com.unity.ml-agents` 和 `com.unity.ml-agents.extensions`的 `package.json`

2. 下载[Anaconda](https://www.anaconda.com/products/individual#Downloads)

3. 运行`Anaconda Prompt`

4. `conda create -n ml-agents python=3.6`

5. `activate ml-agents`

6. ```
   pip3 install torch~=1.7.1 scipy matplotlib -i https://pypi.tuna.tsinghua.edu.cn/simple
   ```

7. ```
   python -m pip install mlagents==0.25.0 scipy matplotlib -i https://pypi.tuna.tsinghua.edu.cn/simple
   ```

8. `cd  /d F:\Github\ml-agents-release_15`

9. ```
   pip3 install -e ./ml-agents-envs scipy matplotlib -i https://pypi.tuna.tsinghua.edu.cn/simple
   pip3 install -e ./ml-agents scipy matplotlib -i https://pypi.tuna.tsinghua.edu.cn/simple
   ```

# 测试开发环境

1. `cd  /d F:\Github\ml-agents-release_15`
2. `mlagents-learn config\3DBall.yaml --run-id=3DBall --train`

# Unity 路线生成插件

