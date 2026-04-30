# Agentic AI & GitHub Copilot — 1‑Hour C# Lab (Copilot Free) with MCP Tools

This repository contains a **time-boxed, corporate-friendly hands-on lab** that teaches **Agentic AI concepts** using **GitHub Copilot** in **VS Code** and a **shared MCP server** hosted in Azure.

It is designed for environments where learners:
- use **their own personal GitHub accounts**
- are on the **GitHub Copilot Free plan**
- work inside a **Linux lab container** with **VS Code preinstalled**

---

## For lab developers (design + facilitation guide)

### Lab title
**Agentic AI & GitHub Copilot (C#): Tool‑using workflows with MCP**

### Audience / level
- Audience: Developers familiar with basic Git + C#
- Level: Intro → Intermediate (focus on workflow, not deep frameworks)

### Duration
- **60 minutes lab time** (fits inside a 2-hour session that includes intro/Q&A)

### Learning objectives
By the end of the lab, students will be able to:

1. **Explain an unfamiliar C# codebase** using Copilot Chat (scoped prompts).
2. **Implement a small function** using Copilot code completions (and minimal chat).
3. **Fix a bug** using a Copilot-guided, test-driven approach.
4. **Refactor code** safely (behavior-preserving refactor).
5. Understand (and observe) an **agentic tool-use loop** by connecting VS Code to a **shared MCP server** and using it to retrieve context.

### Key constraints (Copilot Free)
Copilot Free includes limited usage per month. To keep this lab reliable:
- Target **≤ 50%** of the Copilot Free **chat/agent** quota.
- Design the lab to require **~6–10 chat requests** total.
- Prefer **code completions** (Tab) over repeated chat iterations.

> Instructor tip: Most “quota burn” comes from back-and-forth debugging conversations.
> Prevent “prompt ping‑pong” by giving students a fixed prompt pack (below).

### Proposed lab flow (high level)
1. Open repo in VS Code.
2. Run tests (verify baseline).
3. Copilot: explain the project + one function/class.
4. Implement a small function (mostly via completions).
5. Run tests (observe failure).
6. Use Copilot to locate and fix the bug.
7. Refactor one method (small and safe).
8. Configure MCP (copy/paste) and run one “agentic” prompt where Copilot uses tools.

### Repo layout (recommended)
Create these folders in this repo:
- `assets/` — screenshots / diagrams used by the README
- `app/` — the C# solution students work on (keep it small and fast)

> If `app/` is empty today, add it before delivery. The lab depends on a working C# project.

### Instructor preparation checklist (do this before the cohort)
**Environment**
- Confirm learners can sign in to GitHub from VS Code in the Linux container.
- Confirm the **GitHub Copilot** + **Copilot Chat** extensions are installed and enabled.
- Confirm `dotnet --version` is available (recommend **.NET 8**).

**Repo readiness**
- Ensure `app/` contains:
  - a buildable C# solution
  - a test project with at least 1–2 unit tests
  - **one intentionally failing test** or a controlled bug scenario

**MCP readiness**
- Deploy the shared MCP server to Azure (Function App Consumption is fine).
- Validate the endpoint from inside the lab environment network.
- Decide how students authenticate (recommended: Function Key header/query string).
- Make sure MCP tool responses are **small and deterministic** (truncate files, limit search results).

**Dry-run the student experience**
- Run through the lab once using a **fresh Copilot Free** account (or simulate low usage).
- Confirm the “agentic MCP” demo works with **1–2 prompts max**.

### MCP server notes (what to build / host)
To keep this lab stable, the MCP server should expose **read-only** tools such as:
- `get_lab_instructions(section?: string)`
- `search_repo(query: string)`
- `get_file(path: string, startLine?: int, endLine?: int)`

Avoid write tools in a classroom setting.

### Troubleshooting guidance (common)
- **Copilot Chat not available**: student may not have Copilot entitlement enabled; have them verify Copilot is active in VS Code.
- **Quota exceeded**: student has already used Copilot this month. Provide “buddy mode” (pair up) or allow them to follow without Copilot prompts.
- **dotnet restore/build slow**: keep dependencies minimal; consider `dotnet test` only once at the start and once after the bug fix.
- **MCP connection fails**: fall back to a screenshot/video demo or instructor-led demonstration.

### Reset between cohorts
- If using shared lab containers: ensure the `app/` folder is reset to its starting state.
- Remove any generated artifacts:
  - `bin/`, `obj/`, `.vs/`, `TestResults/`
- If students push changes to their own forks, no reset is needed in this repo.

---

## Student lab guide (step-by-step)

### What you will do (in 1 hour)
You will use GitHub Copilot in VS Code to:
1) explain code  
2) create a function  
3) fix a bug (using tests)  
4) refactor a method  
5) connect to an MCP server and perform one tool-using “agentic” task  

### Prerequisites
- A personal GitHub account you can sign into in the lab environment
- Internet access from the Linux lab container
- VS Code already installed (provided)
- `.NET SDK` available in the container (recommended: .NET 8)

---

## Part 0 — Open the project (5 minutes)

1. Open **VS Code**.
2. Sign in to GitHub:
   - Open Command Palette: `Ctrl+Shift+P`
   - Run: **GitHub: Sign in**
   - Complete browser/device sign-in as prompted.
3. Clone this repository:
   - In VS Code: `Ctrl+Shift+P` → **Git: Clone**
   - Paste:
     - `https://github.com/LukeDuffy98/Agentic-AI-and-GitHub-Copilot.git`
4. Open the folder in VS Code when prompted.
5. Open a terminal in VS Code: **Terminal → New Terminal**
6. Go to the app folder:
   ```bash
   cd app
   ```

## Part 1 — Build and run tests (5 minutes)

1. Restore dependencies:
   ```bash
   dotnet restore
   ```
2. Run tests (baseline):
   ```bash
   dotnet test
   ```

If tests fail immediately, tell your instructor (the repo may not be in the expected start state).

## Part 2 — Explain code (8 minutes | budget: 2 chat requests)

Open Copilot Chat (usually `Ctrl+Alt+I`).

### Prompt 1 (project-level, short)
```text
@workspace Describe this project in 5 bullets. Name the key entry points and main folders.
```

### Prompt 2 (file-level, focused)
Open a core file in the editor (your instructor will point you to one), then ask:

```text
#editor Explain what this file does. List key classes/functions and how they interact.
```

> Tip: Keep questions narrow to avoid burning chat requests.

## Part 3 — Create a function (10 minutes | budget: 1–2 chat requests)

Your instructor will direct you to a TODO in the codebase (a stub method).

### Preferred approach (use completions)
1. Place your cursor inside the stub method.
2. Start typing the first line of the implementation.
3. Accept Copilot suggestions with **Tab**.
4. Run tests:
   ```bash
   dotnet test
   ```

### Optional prompt (only if you’re stuck)
Select the stub method and use:

```text
#selection Implement this method. Keep it deterministic and add input validation.
```

## Part 4 — Fix a bug (12 minutes | budget: 2–4 chat requests)

There will be a controlled failing test (or you will create one quickly).

1. Run tests and identify the failing test:
   ```bash
   dotnet test
   ```

2. Open the failing test and the related production code.

### Prompt template (run once)
Paste the failing test name and error message:

```text
I have a failing test: <TEST_NAME>.
Here is the error message:
<PASTE ERROR>
Identify the most likely root cause and propose a minimal fix. Keep behavior changes limited to what the test expects.
```

3. Apply the minimal fix.
4. Re-run tests:
   ```bash
   dotnet test
   ```

> Rule: If you need more than 2 retries, ask the instructor. Don’t burn your quota.

## Part 5 — Refactor (10 minutes | budget: 1–2 chat requests)

Your instructor will point you to a “refactor target” method (usually a loop that can be simplified).

1. Select the method body in the editor.

### Prompt (behavior-preserving refactor)
```text
#selection Refactor this code to improve readability without changing behavior. Prefer LINQ where it makes sense and keep it testable.
```

2. Run tests to confirm behavior didn’t change:
   ```bash
   dotnet test
   ```

## Part 6 — Agentic demo: connect to the shared MCP server (10 minutes)

This section shows how Copilot can **use tools** (MCP) to retrieve context, not just autocomplete.

> Your instructor will provide the MCP server URL and key.

### MCP configuration (placeholders)
You will configure an MCP server endpoint in VS Code.

- MCP Server URL: `https://<YOUR-FUNCTION-APP>.azurewebsites.net/api/<YOUR-ENDPOINT>`
- MCP Key: `<YOUR_FUNCTION_KEY>`

> Exact configuration steps depend on the MCP client extension used in your environment.
> Your instructor will tell you where to paste the server configuration JSON.

### “Agentic” prompt (use once)
After MCP is connected, run:

```text
Use the available tools to locate the file that contains <FEATURE_OR_CLASS_NAME>, then summarize how it works and where I should make a change to implement <SMALL_CHANGE>.
```

You should see the tool calls and results in the UI (depending on the MCP client integration).

## Copilot Free “request budget” (important)
To keep within the free plan limits, aim for:
- **≤ 10 chat requests** for the whole lab
- Prefer **Tab completions** for implementation
- Ask the instructor rather than re-prompting 5+ times

## If something doesn’t work
- Copilot chat not responding: confirm you are signed into GitHub in VS Code.
- “No entitlement” / Copilot unavailable: you may not have Copilot enabled on your account.
- MCP step fails: follow along with the instructor demo and continue the coding steps.

## Appendix — Prompt pack (copy/paste)
Use these prompts **once each** (max):

1. Project summary  
   `@workspace Describe this project in 5 bullets. Name the key entry points and main folders.`

2. Explain current file  
   `#editor Explain what this file does. List key classes/functions and how they interact.`

3. Implement function  
   `#selection Implement this method. Keep it deterministic and add input validation.`

4. Debug failing test  
   `I have a failing test: <TEST_NAME>. Here is the error message: <PASTE ERROR>. Identify the most likely root cause and propose a minimal fix.`

5. Refactor  
   `#selection Refactor this code to improve readability without changing behavior.`

6. Agentic tool-use  
   `Use the available tools to locate the file that contains <X>, then summarize how it works and where I should make a change to implement <Y>.`

---

## Next steps (for maintainers)
- Add the C# solution under `app/`.
- Add a small failing test scenario.
- Add screenshots under `assets/` once the MCP client configuration is finalized.
