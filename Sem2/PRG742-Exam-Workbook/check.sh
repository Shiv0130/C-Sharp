#!/usr/bin/env bash
# Run your auto-checks and see a score per question.   Usage:  ./check.sh        (or: ./check.sh Q2_1  to see one question)
cd "$(dirname "$0")" || exit 1
FILTER="$1"
ARGS=()
[ -n "$FILTER" ] && ARGS=(--filter "FullyQualifiedName~${FILTER}")

OUT=$(dotnet test HospitalApp.Tests --nologo --logger "console;verbosity=normal" "${ARGS[@]}" 2>&1)

# If it did not even build, show the compiler errors and stop.
if ! echo "$OUT" | grep -qE '^\s+(Passed|Failed) '; then
  echo "$OUT" | grep -E "error|Error" | sort -u | head -30
  echo; echo "The project did not build. Fix the red errors above first."
  exit 1
fi

echo "$OUT" | awk '
BEGIN {
  marks["Q1_1"]=5;  marks["Q1_2"]=5;  marks["Q1_3"]=5;  marks["Q1_4"]=5;
  marks["Q2_1"]=15; marks["Q2_2"]=15;
  marks["Q3_1"]=20; marks["Q3_2"]=15; marks["Q3_3"]=15;
  n=split("Q1_1 Q1_2 Q1_3 Q1_4 Q2_1 Q2_2 Q3_1 Q3_2 Q3_3 B1 B2 B3 B4 B5 B6 B7", order, " ");
  title["Q1_1"]="Q1.1 REST and HTTP methods";   title["Q1_2"]="Q1.2 EF Core migrations";
  title["Q1_3"]="Q1.3 ViewBag vs TempData";     title["Q1_4"]="Q1.4 Data annotations";
  title["Q2_1"]="Q2.1 Patient model";           title["Q2_2"]="Q2.2 DbContext + Fluent API";
  title["Q3_1"]="Q3.1 Controller + TempData";   title["Q3_2"]="Q3.2 Create view + dropdown";
  title["Q3_3"]="Q3.3 Index view + loop";       title["B1"]="B1 ERD (bonus)";
  title["B2"]="B2 Seeding (bonus)";             title["B3"]="B3 Include (bonus)";
  title["B4"]="B4 Async (bonus)";               title["B5"]="B5 Edit/Delete (bonus)";
  title["B6"]="B6 @if in a view (bonus)";       title["B7"]="B7 Migrations (bonus)";
}
function flush() {
  if (ptag != "") {
    if (pmsg == "") pmsg = "(see the test name)"
    key = ptag SUBSEP pmsg
    if (!(key in seen)) { seen[key]=1; failtxt[ptag]=failtxt[ptag] "      x " pname "\n        -> " pmsg "\n" }
  }
  ptag=""; pname=""; pmsg=""; expect=0
}
/^[[:space:]]+(Passed|Failed) / {
  flush()
  status=$1; tag=""
  if (match($0, /(Q[0-9]_[0-9]|B[0-9])_/)) tag=substr($0, RSTART, RLENGTH-1)
  if (tag != "") {
    tot[tag]++
    if (status == "Passed") pass[tag]++
    else {
      name=$0; sub(/^[[:space:]]+Failed[[:space:]]+/, "", name); sub(/ \[[0-9<].*$/, "", name); sub(/^.*Tests\./, "", name)
      ptag=tag; pname=name; expect=1; failed[tag]=1
    }
  }
  next
}
/Error Message:/ { if (expect==1) expect=2; next }
/Stack Trace:/ { if (expect==2) expect=0; next }
{ if (expect==2 && $0 ~ /[^[:space:]]/) { m=$0; sub(/^[[:space:]]*(>> )?/, "", m); pmsg=m; expect=0 } }
END {
  flush()
  totalMarks=0; gotMarks=0
  print ""; print "  PRG742 workbook: your score so far"; print "  ----------------------------------------------------------"
  for (i=1;i<=n;i++) {
    t=order[i]; if (!(t in tot)) continue
    p=pass[t]+0; bar=""
    for (k=0;k<10;k++) bar = bar ((k < p*10/tot[t]) ? "#" : ".")
    if (t in marks) { got=int(p/tot[t]*marks[t]+0.5); totalMarks+=marks[t]; gotMarks+=got; ms=sprintf("%2d/%2d marks", got, marks[t]) }
    else ms="   bonus   "
    printf "  %-30s [%s] %2d/%-2d checks  %s\n", title[t], bar, p, tot[t], ms
  }
  print "  ----------------------------------------------------------"
  printf "  Paper total (rough, from auto-checks): %d / %d\n\n", gotMarks, totalMarks
  any=0
  for (i=1;i<=n;i++) { t=order[i]; if (failtxt[t] != "") { if (!any) { print "  Still to fix:"; any=1 } print "    " title[t]; printf "%s", failtxt[t] } }
  if (!any) print "  Everything is green. Now go and read the rubric for the theory with fresh eyes.\n"
  print ""
}'
