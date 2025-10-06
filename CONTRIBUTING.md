# Git Workflow Guide - Rastro Project

## 1. Starting a New Feature

### 1.1. Create and Switch to New Branch
```sh
# Update main first
git checkout main
git pull origin main

# Create and switch to new branch
git checkout -b feature/feature-name
```

**Branch Naming Patterns:**
- `feature/` - New features
- `fix/` - Bug fixes
- `refactor/` - Code refactoring
- `docs/` - Documentation

## 2. Working on the Feature

### 2.1. Check Changes Status
```sh
# View modified files
git status

# View specific changes
git diff
```

### 2.2. Stage and Commit Changes
```sh
# Add changes
git add .              # All files
git add file.cs        # Specific file

# Create commit
git commit -m "type: change description"
```

**Commit Message Patterns:**
- `feat:` - New feature
- `fix:` - Bug fix
- `refactor:` - Code refactoring
- `docs:` - Documentation
- `style:` - Formatting
- `test:` - Tests

### 2.3. Push Changes to GitHub
```sh
# First time
git push -u origin feature/feature-name

# Subsequent times
git push
```

## 3. Integrating Feature into Main

### 3.1. Update Main Branch
```sh
# Switch to main
git checkout main

# Download updates
git pull origin main
```

### 3.2. Perform Merge
```sh
# Merge feature into main
git merge feature/feature-name
```

### 3.3. Resolve Conflicts (if necessary)
```sh
# If there are conflicts:
1. Open conflicting files in Visual Studio
2. Choose correct changes
3. Save files
4. git add .
5. git commit -m "merge: Integrates feature/feature-name"
```

### 3.4. Push to GitHub
```sh
# Push merged changes
git push origin main
```

## 4. Post-Merge Cleanup

### 4.1. Remove Branches
```sh
# Remove local branch
git branch -d feature/feature-name

# Remove remote branch
git push origin --delete feature/feature-name
```

## 5. Useful Commands

### 5.1. Branch Management
```sh
# List branches
git branch                    # Local
git branch -a                 # All

# Switch branch
git checkout branch-name

# Create new branch
git checkout -b new-branch
```

### 5.2. Fixes and Adjustments
```sh
# Undo uncommitted changes
git restore file.cs

# Undo last commit (keeping changes)
git reset --soft HEAD~1

# Abort merge with conflicts
git merge --abort
```

## 6. Best Practices

1. **Branches**
   - One branch per feature/fix
   - Keep branches updated with main
   - Delete branches after merge

2. **Commits**
   - Small and focused commits
   - Clear and descriptive messages
   - Use type prefixes appropriately

3. **Merge**
   - Always update main before merging
   - Test after resolving conflicts
   - Verify application still works

4. **General**
   - Keep your local code updated
   - Commit frequently
   - Document important changes

## 7. Workflow Summary

```sh
# 1. Start Feature
git checkout main
git pull origin main
git checkout -b feature/new-feature

# 2. Develop
git add .
git commit -m "feat: Implements new feature"
git push -u origin feature/new-feature

# 3. Finish and Integrate
git checkout main
git pull origin main
git merge feature/new-feature
git push origin main

# 4. Cleanup
git branch -d feature/new-feature
git push origin --delete feature/new-feature```