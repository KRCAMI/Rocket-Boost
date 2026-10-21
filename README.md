# Rocket Boost - 3D 로켓 물리 제어 및 장애물 돌파 게임

Unity 6 (URP) 환경에서 개발한 3D 로켓 시뮬레이션 및 아케이드 게임입니다. 
유저의 조작감을 극대화하기 위해 프레임 독립적인 물리 연산(Rigidbody)과 정교한 충돌 판정 시스템을 구현했습니다.

## 플레이 화면
<img width="1919" height="1079" alt="스크린샷 2026-10-22 070946" src="https://github.com/user-attachments/assets/dd3af8f4-e34a-4ba3-9c61-d2aea8244ec4" />

##  개발 환경 및 기술 스택
* **Engine:** Unity 6.3 LTS (6000.3.10f1) - Universal Render Pipeline (URP)
* **Language:** C#

## 핵심 구현 기능 (`Assets/Scripts`)
1. Movement.cs (로켓 물리 제어)
   Rigidbody.AddRelativeForce를 활용한 로켓 추력(Thrust) 구현
   freezeRotation 좌우 회전 시 물리 엔진의 회전 간섭을 제어
   
2. CollisionHandler.cs (충돌 판정 및 상태 전이)
   Switch문과 태그(Friendly, Finish) 기반의 명확한 충돌 분기 처리
   충돌 및 클리어 시 파티클(Particle System)·오디오 피드백 연동 및 SceneManager를 통한 스테이지 전환
   
3. Oscillator.cs (동적 장애물 구현)
   Mathf.Sin와 Time.time을 활용하여 지정된 이동 벡터 구간을 부드럽게 왕복하는 장애물 로직 구현
   
4. QuitApplication.cs (종료)
   * 빌드 환경에서의 게임 종료 및 디버그 단축키 처리
