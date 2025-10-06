# Guia de Trabalho com Git - Projeto Rastro

## 1. Iniciando uma Nova Feature

### 1.1. Criar e Mudar para Nova Branch
```sh
# Atualizar a main primeiro
git checkout main
git pull origin main

# Criar e mudar para nova branch
git checkout -b feature/nome-da-feature
```

**Padrões para nomes de branches:**
- `feature/` - Novas funcionalidades
- `fix/` - Correções de bugs
- `refactor/` - Refatorações
- `docs/` - Documentação

## 2. Trabalhando na Feature

### 2.1. Verificar Status das Alterações
```sh
# Ver arquivos modificados
git status

# Ver alterações específicas
git diff
```

### 2.2. Preparar e Commitar Alterações
```sh
# Adicionar alterações
git add .              # Todos os arquivos
git add arquivo.cs     # Arquivo específico

# Criar commit
git commit -m "tipo: descrição das alterações"
```

**Padrões de Mensagens de Commit:**
- `feat:` - Nova funcionalidade
- `fix:` - Correção de bug
- `refactor:` - Refatoração
- `docs:` - Documentação
- `style:` - Formatação
- `test:` - Testes

### 2.3. Enviar Alterações para GitHub
```sh
# Primeira vez
git push -u origin feature/nome-da-feature

# Próximas vezes
git push
```

## 3. Integrando a Feature na Main

### 3.1. Atualizar Branch Principal
```sh
# Mudar para main
git checkout main

# Baixar atualizações
git pull origin main
```

### 3.2. Realizar o Merge
```sh
# Mesclar feature na main
git merge feature/nome-da-feature
```

### 3.3. Resolver Conflitos (se necessário)
```sh
# Se houver conflitos:
1. Abrir arquivos com conflitos no Visual Studio
2. Escolher as alterações corretas
3. Salvar arquivos
4. git add .
5. git commit -m "merge: Integra feature/nome-da-feature"
```

### 3.4. Enviar para GitHub
```sh
# Enviar alterações mescladas
git push origin main
```

## 4. Limpeza Pós-Merge

### 4.1. Remover Branches
```sh
# Remover branch local
git branch -d feature/nome-da-feature

# Remover branch remota
git push origin --delete feature/nome-da-feature
```

## 5. Comandos Úteis

### 5.1. Gerenciamento de Branches
```sh
# Listar branches
git branch                    # Locais
git branch -a                 # Todas

# Mudar de branch
git checkout nome-branch

# Criar nova branch
git checkout -b nova-branch
```

### 5.2. Correções e Ajustes
```sh
# Desfazer alterações não commitadas
git restore arquivo.cs

# Desfazer último commit (mantendo alterações)
git reset --soft HEAD~1

# Abortar merge com conflitos
git merge --abort
```

## 6. Boas Práticas

1. **Branches**
   - Uma branch por feature/correção
   - Mantenha branches atualizadas com a main
   - Delete branches após merge

2. **Commits**
   - Commits pequenos e focados
   - Mensagens claras e descritivas
   - Use os prefixos de tipo adequadamente

3. **Merge**
   - Sempre atualize a main antes do merge
   - Teste após resolver conflitos
   - Verifique se a aplicação continua funcionando

4. **Geral**
   - Mantenha seu código local atualizado
   - Faça commits frequentes
   - Documente alterações importantes

## 7. Fluxo de Trabalho Resumido

```sh
# 1. Iniciar Feature
git checkout main
git pull origin main
git checkout -b feature/nova-funcionalidade

# 2. Desenvolver
git add .
git commit -m "feat: Implementa nova funcionalidade"
git push -u origin feature/nova-funcionalidade

# 3. Finalizar e Integrar
git checkout main
git pull origin main
git merge feature/nova-funcionalidade
git push origin main

# 4. Limpar
git branch -d feature/nova-funcionalidade
git push origin --delete feature/nova-funcionalidade
```