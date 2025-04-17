# Flow CLI

## Commands

* **Default run** (no arguments).
  - Pomodoro Mode.
  - Focus: 25 minutes.
  - Break: 5 minutes.

* **Custom run** (with arguments).
  - Required: `flow <name> <minutes>`.
  - Optional: `--break <minutes>` or `-b <minutes>`.
    - If you skip it, there won’t be a break.

### Examples:

- **Default Pomodoro**: `flow` </br>
![Image Pomodoro Mode](assets/pomodoro-mode.jpg)
- **Custom (no break)**: `flow Study 2` </br>
![Image Custom no Break](assets/custom-no-break.jpg)
- **Custom (with break)**: `flow Study 2 -b 1` </br>
![Image Custom with Break](assets/custom-with-break.jpg)
